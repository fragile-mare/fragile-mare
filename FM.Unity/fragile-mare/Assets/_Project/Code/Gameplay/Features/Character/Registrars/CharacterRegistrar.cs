using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Character.Registrars
{
    public class CharacterRegistrar : MonoBehaviour
    {
        public float speed;
        
        private GameEntity _entity;

        private void Awake()
        {
            _entity = CreateEntity
                .Empty()
                .AddTransform(transform)
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(speed)
                .With(x => x.isCharacter = true);
        }
    }
}