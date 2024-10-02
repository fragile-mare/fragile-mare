using System.Collections.Generic;
using Entitas;

namespace _Project.Code.Gameplay.Features.Effect.Systems
{
    public class DestroyAppliedEffectsCleanupSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private readonly IGroup<GameEntity> _effects;

        public DestroyAppliedEffectsCleanupSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.Effect,
                    GameMatcher.Applied)
                .NoneOf(GameMatcher.Destructed));
        }

        public void Cleanup()
        {
            foreach (GameEntity effect in _effects.GetEntities(_buffer))
            {
                effect.isDestructed = true;
            }
        }
    }
}