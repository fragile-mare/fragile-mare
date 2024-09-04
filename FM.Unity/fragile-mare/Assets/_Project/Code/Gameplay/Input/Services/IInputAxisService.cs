using UnityEngine;

namespace _Project.Code.Gameplay.Input.Services
{
    public interface IInputAxisService
    {
        Vector2 GetAxisInput();
        bool HasAxisInput();
    }
}