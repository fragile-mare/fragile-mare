using UnityEngine.InputSystem;

namespace _Project.Code.Gameplay.Input.Button.Services
{
    public class GamepadInputButtonService : IInputButtonService
    {
        public bool IsSprintPressed()
        {
            var gamepad = Gamepad.current;
            if (gamepad == null) return false;
            
            return gamepad.buttonEast.IsPressed();
        }

        public bool IsDashPressed()
        {
            var gamepad = Gamepad.current;
            if (gamepad == null) return false;
            
            return gamepad.buttonEast.wasPressedThisFrame;
        }
    }
}