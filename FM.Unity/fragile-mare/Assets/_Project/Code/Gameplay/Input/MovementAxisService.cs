using UnityEngine;

namespace _Project.Code.Game.Input
{
    public class MovementAxisService : IMovementAxisService
    {
        public Vector2 GetAxis()
        {
            return new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
        }
    }
}