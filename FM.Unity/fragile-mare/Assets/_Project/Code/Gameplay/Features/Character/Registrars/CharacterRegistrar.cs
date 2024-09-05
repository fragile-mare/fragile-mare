using _Project.Code.Common.Entity;
using _Project.Code.Common.Extensions;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Character.Registrars
{
    public class CharacterRegistrar : MonoBehaviour
    {
        public float speed;
        public float sprintSpeed;
        public float dashSpeed;
        public float dashDuration;
        public int dashMaxCount;
        public float dashRegenDuration;
        public int dashRegenAmount;
        
        private GameEntity _entity;
        
        private void Awake()
        {
            _entity = CreateEntity
                .Empty()
                .AddTransform(transform)
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(speed)
                .AddSprintSpeed(sprintSpeed)
                .AddDashSpeed(dashSpeed)
                .AddDashDuration(dashDuration)
                .AddDashTimer(0)
                .AddDashMaxCount(dashMaxCount)
                .AddDashCurrentCount(dashMaxCount)
                .AddDashRegenDuration(dashRegenDuration)
                .AddDashRegenTimer(dashRegenDuration)
                .AddDashRegenAmount(dashRegenAmount)
                .With(x => x.isCharacter = true)
                .With(x => x.isCanMove = true)
                .With(x => x.isCanSprint = true)
                .With(x => x.isCanDash = true);
        }
    }
}