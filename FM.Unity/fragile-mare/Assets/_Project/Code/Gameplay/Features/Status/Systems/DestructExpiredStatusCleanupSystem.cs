using System.Collections.Generic;
using Entitas;

namespace _Project.Code.Gameplay.Features.Status.Systems
{
    public class DestructExpiredStatusCleanupSystem : ICleanupSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private readonly IGroup<GameEntity> _group;

        public DestructExpiredStatusCleanupSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Status, GameMatcher.Expired)
                .NoneOf(GameMatcher.Destructed));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.isDestructed = true;
            }
        }
    }
}