using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class PlayerInput : IPlayerInput
    {
        public event Action OnMoveLeft;
        public event Action OnMoveRight;
        
        private const float SwipeThreshold = 50f;

        private readonly InputActions _inputActions = new();

        private Vector2 _startTouchPos;
        private Vector2 _endTouchPos;
        private bool _isTouching;
        
        public void Initialize()
        {
            _inputActions.Gameplay.Enable();
            _inputActions.Gameplay.TouchPress.started += StartTouch;
            _inputActions.Gameplay.TouchPress.canceled += EndTouch;
            _inputActions.Gameplay.Move.performed += Move;
        }

        public void Dispose()
        {
            _inputActions.Gameplay.TouchPress.started -=  StartTouch;
            _inputActions.Gameplay.TouchPress.canceled -= EndTouch;
            _inputActions.Gameplay.Move.performed -= Move;
            _inputActions.Gameplay.Disable();
        }

        private void StartTouch(InputAction.CallbackContext _)
        {
            _isTouching = true;
            _startTouchPos = _inputActions.Gameplay.TouchDelta.ReadValue<Vector2>();
        }

        private void EndTouch(InputAction.CallbackContext _)
        {
            if (!_isTouching) 
                return;
            
            _isTouching = false;
            _endTouchPos = _inputActions.Gameplay.TouchDelta.ReadValue<Vector2>();

            var swipe = _endTouchPos - _startTouchPos;
            
            if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y) && Mathf.Abs(swipe.x) > SwipeThreshold)
            {
                if (swipe.x > 0)
                    OnMoveRight?.Invoke();
                else
                    OnMoveLeft?.Invoke();
            }
        }

        private void Move(InputAction.CallbackContext callbackContext)
        {
            var x = callbackContext.ReadValue<float>();

            if (x > 0.5f)
                OnMoveRight?.Invoke();
            else if (x < -0.5f)
                OnMoveLeft?.Invoke();
        }
    }
}
