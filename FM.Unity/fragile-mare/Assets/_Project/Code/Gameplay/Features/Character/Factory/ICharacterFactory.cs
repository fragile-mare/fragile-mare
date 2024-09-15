using UnityEngine;

namespace _Project.Code.Gameplay.Features.Character.Factory
{
    public interface ICharacterFactory
    {
        GameEntity CreateCharacter(Vector3 at, Quaternion rotation);
    }
}