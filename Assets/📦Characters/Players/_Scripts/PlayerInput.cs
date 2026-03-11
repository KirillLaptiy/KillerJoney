using UnityEngine;
using UnityEngine.InputSystem;

namespace __Characters.Players._Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        public static Vector2 MoveInput { get; private set; }
        public static Vector2 ShootInput { get; private set; }

        [SerializeField] private bool isAutoShooting;

        private Camera _playerCamera;

        private void Awake()
        {
            _playerCamera = GetComponentInChildren<Camera>();
        }

        private void Update()
        {
            MoveInput = UpdateMoveInput();
            ShootInput = UpdateShootInput();
        }

        // MOVE INPUT UPDATING
        private static Vector2 UpdateMoveInput()
        {
            if (Keyboard.current == null) return Vector2.zero;

            float x = 0f, y = 0f;

            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) x = -1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) x = 1f;
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) y = 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) y = -1f;

            return new Vector2(x, y).normalized;
        }

        // SHOOT INPUT UPDATING
        private Vector2 UpdateShootInput()
        {
            return isAutoShooting ? GetShootInputAuto() : GetShootInputManual();
        }

        private Vector2 GetShootInputAuto()
        {
            return new Vector2(0, 0);
        }

        private Vector2 GetShootInputManual()
        {
            if (Mouse.current == null) return Vector2.zero;

            var mouseScreenPos = Mouse.current.position.ReadValue();

            var mouseWorldPos = _playerCamera.ScreenToWorldPoint(mouseScreenPos);
            
            Vector2 direction = (mouseWorldPos - transform.position);

            return direction.normalized;
        }
    }
}