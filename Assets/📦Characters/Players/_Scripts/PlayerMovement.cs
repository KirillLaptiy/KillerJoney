using Core;
using Core.Animations;
using Mirror;
using UnityEngine;

namespace __Characters.Players._Scripts
{
    public class PlayerMovement : NetworkBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

        private Rigidbody2D _rb;
        private Animator _animator;

        private Vector2 _moveInput;
        private bool _isWalking;
        private float _walkDirection;

        public Rigidbody2D Rigidbody => _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            if (!isLocalPlayer) return;
            
            SetMoveInput(PlayerInput.MoveInput);
            TickMovement();
            TickAnimator();
        }

        private void SetMoveInput(Vector2 input)
        {
            _moveInput = input;

            if (_moveInput != Vector2.zero)
            {
                _isWalking = true;

                if (Mathf.Abs(_moveInput.x) > Mathf.Abs(_moveInput.y))
                    _walkDirection = _moveInput.x > 0 ? Directions.Right : Directions.Left;
                else
                    _walkDirection = _moveInput.y > 0 ? Directions.Up : Directions.Down;
            }
            else
            {
                _isWalking = false;
                _walkDirection = Directions.Idle;
            }
        }

        private void TickMovement()
        {
            _rb.linearVelocity = _moveInput * TileUnit.ToWorld(moveSpeed);
        }

        private void TickAnimator()
        {
            _animator.SetFloat(AnimConditions.MovingDirection, _walkDirection);
            _animator.SetBool(AnimConditions.Walking, _isWalking);
        }

        public void TeleportTo(Vector3 position)
        {
            _rb.position = new Vector2(position.x, position.y);
        }

        public PlayerState GetState(double timestamp)
        {
            return new PlayerState
            {
                position = _rb.position,
                velocity = _rb.linearVelocity,
                rotation = _rb.rotation,
                angularVelocity = _rb.angularVelocity,
                timestamp = timestamp
            };
        }
    }
}