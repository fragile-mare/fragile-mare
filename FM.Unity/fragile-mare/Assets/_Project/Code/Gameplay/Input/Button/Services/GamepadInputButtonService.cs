using UnityEngine.InputSystem;

namespace _Project.Code.Gameplay.Input.Button.Services
{
    public class GamepadInputButtonService : IInputButtonService
    {
        public bool IsSprintPressed()
        {
            return Gamepad.current.buttonEast.IsPressed();
        }

        public bool IsDashPressed()
        {
            return Gamepad.current.buttonEast.wasPressedThisFrame;
        }
    }
}