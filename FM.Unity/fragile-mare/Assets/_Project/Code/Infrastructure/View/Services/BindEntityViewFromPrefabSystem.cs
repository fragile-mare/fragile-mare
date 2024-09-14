using System.Collections.Generic;
using _Project.Code.Infrastructure.View.Factory;
using Entitas;

namespace _Project.Code.Infrastructure.View.Services
{
    public class BindEntityViewFromPrefabSystem : IExecuteSystem
    {
        private readonly IEntityViewFactory _viewFactory;
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);

        public BindEntityViewFromPrefabSystem(GameContext game, IEntityViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
            _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.ViewPath).NoneOf(GameMatcher.View));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                _viewFactory.CreateViewForEntityFromPrefab(entity);
            }
        }
    }
}