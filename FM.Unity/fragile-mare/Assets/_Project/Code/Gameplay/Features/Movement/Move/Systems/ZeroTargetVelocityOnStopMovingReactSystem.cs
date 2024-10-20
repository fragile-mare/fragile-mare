using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Movement.Move.Systems
{
    public class ZeroTargetVelocityOnStopMovingReactSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;

        public ZeroTargetVelocityOnStopMovingReactSystem(GameContext game) : base(game)
        {
            _game = game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.AnyOf(
                GameMatcher.Moving,
                GameMatcher.Sprinting,
                GameMatcher.Dashing).Removed());

        protected override bool Filter(GameEntity mover) => mover.hasId && mover.hasRigidbody;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity mover in entities)
            foreach (GameEntity status in _game.GetEntitiesWithTargetId(mover.Id))
            {
                if (!status.isAccelerationStatus)
                {
                    return;
                }

                status.ReplaceTargetVelocity(Vector3.zero);
            }
        }
    }
}