using UnityEngine;

namespace _Project.Code.Gameplay.Input.Axis.Services.Mouse
{
    public class CursorPositionService : ICursorPositionService
    {
        public Vector2 GetCursorPosition()
        {
            return new Vector2(UnityEngine.Input.GetAxis("Mouse X"), UnityEngine.Input.GetAxis("Mouse Y"));
        }
    }
}