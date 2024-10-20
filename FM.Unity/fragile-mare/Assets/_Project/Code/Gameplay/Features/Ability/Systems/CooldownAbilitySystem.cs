using System.Collections.Generic;
using _Project.Code.Common.Services.Time;
using Entitas;

namespace _Project.Code.Gameplay.Features.Ability.Systems
{
    public class CooldownAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(32);
        private readonly ITimeService _time;

        public CooldownAbilitySystem(GameContext game, ITimeService time)
        {
            _time = time;
            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Ability, GameMatcher.CooldownTimer, GameMatcher.CooldownInterval)
                .NoneOf(GameMatcher.Ready));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                ability.ReplaceCooldownTimer(ability.CooldownTimer - _time.DeltaTime);

                if (ability.CooldownTimer <= 0)
                {
                    ability.isReady = true;
                    ability.ReplaceCooldownTimer(ability.CooldownInterval);
                }
            }
        }
    }
}