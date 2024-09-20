using UnityEngine;

namespace _Project.Code.Gameplay.Input.Axis.Services
{
    public class CursorDeltaPositionService
    {
        public float HorizontalAxis => UnityEngine.Input.GetAxisRaw("Horisontal");
        public float VerticalAxis => UnityEngine.Input.GetAxisRaw("Vertical");

        private Vector2 lastMousePosition;
        
        public const double Epsilon = 0.0001;
        

        public bool HasAxisInput()
        {
            if (Mathf.Abs(HorizontalAxis) <= Epsilon && Mathf.Abs(VerticalAxis) <= Epsilon)
            {
                return false;
            }

            return true;
        }
    }
}