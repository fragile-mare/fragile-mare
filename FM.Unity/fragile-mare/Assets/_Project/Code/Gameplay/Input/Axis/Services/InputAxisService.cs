using UnityEngine;

namespace _Project.Code.Gameplay.Input.Axis.Services
{
    public class InputAxisService : IInputAxisService
    {
        public float HorizontalAxis => UnityEngine.Input.GetAxis("Horizontal");
        public float VerticalAxis => UnityEngine.Input.GetAxis("Vertical");

        public const double Epsilon = 0.0001;
        
        public Vector2 GetAxisInput()
        {
            return new Vector2(HorizontalAxis, VerticalAxis);
        }

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