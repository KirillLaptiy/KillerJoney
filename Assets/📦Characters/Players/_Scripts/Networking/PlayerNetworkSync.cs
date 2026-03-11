using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace __Characters.Players._Scripts.Networking
{
    public class PlayerNetworkSync : NetworkBehaviour
    {
        private PlayerMovement _movement;

        private readonly List<PlayerState> _stateBuffer = new();

        private const float InterpolationBackTime = 0.05f;

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
        }

        private void FixedUpdate()
        {
            if (isLocalPlayer)
            {
                SendState();
            }
            else
            {
                InterpolateState();
            }
        }

        void SendState()
        {
            var state = _movement.GetState(NetworkTime.time);

            CmdSendState(
                state.position,
                state.velocity,
                state.rotation,
                state.angularVelocity,
                state.timestamp
            );
        }

        [Command(channel = Channels.Unreliable)]
        void CmdSendState(
            Vector2 position,
            Vector2 velocity,
            float rotation,
            float angularVelocity,
            double timestamp)
        {
            RpcReceiveState(position, velocity, rotation, angularVelocity, timestamp);
        }

        [ClientRpc(channel = Channels.Unreliable)]
        void RpcReceiveState(
            Vector2 position,
            Vector2 velocity,
            float rotation,
            float angularVelocity,
            double timestamp)
        {
            if (isLocalPlayer)
                return;

            var state = new PlayerState
            {
                position = position,
                velocity = velocity,
                rotation = rotation,
                angularVelocity = angularVelocity,
                timestamp = timestamp
            };

            _stateBuffer.Add(state);

            if (_stateBuffer.Count > 20)
                _stateBuffer.RemoveAt(0);
        }

        void InterpolateState()
        {
            if (_stateBuffer.Count < 2)
                return;

            double renderTime = NetworkTime.time - InterpolationBackTime;

            for (int i = 0; i < _stateBuffer.Count - 1; i++)
            {
                if (_stateBuffer[i].timestamp <= renderTime &&
                    _stateBuffer[i + 1].timestamp >= renderTime)
                {
                    var from = _stateBuffer[i];
                    var to = _stateBuffer[i + 1];

                    float t = (float)((renderTime - from.timestamp) /
                                      (to.timestamp - from.timestamp));

                    ApplyInterpolatedState(from, to, t);
                    break;
                }
            }
        }

        void ApplyInterpolatedState(PlayerState from, PlayerState to, float t)
        {
            var rb = _movement.Rigidbody;

            rb.position = Vector2.Lerp(from.position, to.position, t);
            rb.rotation = Mathf.LerpAngle(from.rotation, to.rotation, t);

            rb.linearVelocity = Vector2.Lerp(from.velocity, to.velocity, t);
            rb.angularVelocity = Mathf.Lerp(from.angularVelocity, to.angularVelocity, t);
        }
    }
}