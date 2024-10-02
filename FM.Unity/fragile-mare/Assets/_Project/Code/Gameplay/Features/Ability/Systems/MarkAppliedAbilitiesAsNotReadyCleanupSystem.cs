using System.Collections.Generic;
using Entitas;

namespace _Project.Code.Gameplay.Features.Ability.Systems
{
    public class MarkAppliedAbilitiesAsNotReadyCleanupSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public MarkAppliedAbilitiesAsNotReadyCleanupSystem(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Ability, GameMatcher.Applied));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _abilities.GetEntities(_buffer))
            {
                entity.isApplied = false;
                entity.isReady = false;
            }
        }
    }
}