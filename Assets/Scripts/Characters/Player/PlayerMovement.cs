using Core;
using Core.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Move speed (Tiles in second)")] [SerializeField]
        private float moveSpeed = 5f;

        // Object components
        private Rigidbody2D _rb;
        private Animator _animator;

        // Values
        private Vector2 _moveInput;

        // Animator parameters
        private bool _isWalking;
        private float _walkDirection;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            UpdateKeyboardInput();
        }

        private void FixedUpdate()
        {
            UpdateMovement();
            UpdateAnimator();
        }

        public void TeleportTo(Vector3 position)
        {
            _rb.position = new Vector2(position.x, position.y);
        }

        private void UpdateKeyboardInput()
        {
            if (Keyboard.current != null)
            {
                var x = 0f;
                var y = 0f;

                if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) x = -1f;
                if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) x = 1f;
                if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) y = 1f;
                if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) y = -1f;

                _moveInput = new Vector2(x, y).normalized;
            }
            else
            {
                _moveInput = Vector2.zero;
            }

            if (_moveInput != Vector2.zero)
            {
                _isWalking = true;

                if (Mathf.Abs(_moveInput.x) > Mathf.Abs(_moveInput.y))
                {
                    _walkDirection = _moveInput.x > 0 ? Directions.Right : Directions.Left;
                }
                else
                {
                    _walkDirection = _moveInput.y > 0 ? Directions.Up : Directions.Down;
                }
            }
            else
            {
                _isWalking = false;
                _walkDirection = Directions.Idle;
            }
        }

        private void UpdateMovement()
        {
            _rb.linearVelocity = _moveInput * TileUnit.ToWorld(moveSpeed);
        }

        private void UpdateAnimator()
        {
            _animator.SetFloat(AnimConditions.MovingDirection, _walkDirection);
            _animator.SetBool(AnimConditions.Walking, _isWalking);
        }
    }
}