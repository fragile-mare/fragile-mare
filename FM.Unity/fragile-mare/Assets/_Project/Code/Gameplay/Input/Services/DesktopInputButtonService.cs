using UnityEngine;

namespace _Project.Code.Gameplay.Input.Services
{
    public class DesktopInputButtonService : IInputButtonService
    {
        public bool IsSprintPressed()
        {
            return UnityEngine.Input.GetKey(KeyCode.LeftShift) 
                   || UnityEngine.Input.GetKey(KeyCode.RightShift);
        }

        public bool IsDashPressed()
        {
            return UnityEngine.Input.GetKeyDown(KeyCode.LeftShift)
                   || UnityEngine.Input.GetKeyDown(KeyCode.RightShift);
        }
    }
}