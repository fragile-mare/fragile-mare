using UnityEngine;

namespace _Project.Code.Gameplay.Input.Services
{
    public class InputButtonService : IInputButtonService
    {
        public bool IsSprintPressed()
        {
            return UnityEngine.Input.GetKey(KeyCode.LeftShift) 
                   || UnityEngine.Input.GetKey(KeyCode.RightShift);
        }
    }
}