using UnityEngine;
using UnityEngine.InputSystem;

namespace ST
{
    public class InputManager : MonoBehaviour
    {
        public Vector2 RawMovementInput { get; private set; }
        public Vector2 RawMouseMovementInput { get; private set; }
        public Vector2 RawMousePositionInput { get; private set; }

        public bool EscapeInput { get; private set; }
        public bool EnterInput { get; private set; }
        public bool SpaceInput { get; private set; }

        public bool LShiftInput { get; private set; }
        public bool LControlInput { get; private set; }

        public void OnMovementInput(InputAction.CallbackContext ctx) {
            RawMovementInput = ctx.ReadValue<Vector2>();
        }

        public void OnMouseMovementInput(InputAction.CallbackContext ctx) {
            RawMouseMovementInput = ctx.ReadValue<Vector2>();
        }

        public void OnMousePositionInput(InputAction.CallbackContext ctx) {
            RawMousePositionInput = ctx.ReadValue<Vector2>();
        }

        public void OnEscapeInput(InputAction.CallbackContext ctx) {
            if (ctx.started) {
                EscapeInput = true;
            }

            if (ctx.canceled) {
                EscapeInput = false;
            }
        }

        public void ResetEscapeInput() {
            EscapeInput = false;
        }

        public void OnEnterInput(InputAction.CallbackContext ctx) {
            if (ctx.started) {
                EnterInput = true;
            }

            if (ctx.canceled) {
                EnterInput = false;
            }
        }

        public void ResetEnterInput() {
            EnterInput = false;
        }

        public void OnSpaceInput(InputAction.CallbackContext ctx) {
            if (ctx.started) {
                SpaceInput = true;
            }

            if (ctx.canceled) {
                SpaceInput = false;
            }
        }

        public void ResetSpaceInput() {
            SpaceInput = false;
        }

        public void OnLShiftInput(InputAction.CallbackContext ctx) {
            if (ctx.started) {
                LShiftInput = true;
            }

            if (ctx.canceled) {
                LShiftInput = false;
            }
        }

        public void ResetLShiftInput() {
            LShiftInput = false;
        }

        public void OnLControlInput(InputAction.CallbackContext ctx) {
            if (ctx.started) {
                LControlInput = true;
            }

            if (ctx.canceled) {
                LControlInput = false;
            }
        }

        public void ResetLControlInput() {
            LControlInput = false;
        }
    }
}
