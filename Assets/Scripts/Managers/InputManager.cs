using UnityEngine;
using UnityEngine.InputSystem;

namespace ST
{
    public class InputManager : MonoBehaviour
    {
        public Vector2 RawMovementInput { get; private set; }

        public bool EscapeInput { get; private set; }

        public void OnMovementInput(InputAction.CallbackContext ctx) {
            RawMovementInput = ctx.ReadValue<Vector2>();
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
    }
}
