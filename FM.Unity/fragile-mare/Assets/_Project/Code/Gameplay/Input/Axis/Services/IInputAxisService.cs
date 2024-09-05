using UnityEngine;

namespace _Project.Code.Gameplay.Input.Axis.Services
{
    public interface IInputAxisService
    {
        Vector2 GetAxisInput();
        bool HasAxisInput();
    }
}