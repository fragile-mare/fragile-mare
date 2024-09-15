using UnityEngine;

namespace _Project.Code.Gameplay.Input.Button.Services
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
            return UnityEngine.Input.GetKeyDown(KeyCode.E)
                   || UnityEngine.Input.GetKeyDown(KeyCode.E);
        }
    }
}