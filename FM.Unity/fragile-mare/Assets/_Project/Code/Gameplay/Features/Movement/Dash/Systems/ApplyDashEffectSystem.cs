using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Movement.Dash.Systems
{
    public class ApplyDashEffectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<GameEntity> _targets;

        public ApplyDashEffectSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.DashEffect,
                GameMatcher.EffectValue,
                GameMatcher.TargetId));
            _targets = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Id,
                GameMatcher.Direction,
                GameMatcher.Rigidbody));
        }

        public void Execute()
        {
            foreach (var effect in _effects)
            foreach (var target in _targets)
            {
                if (effect.TargetId != target.Id)
                {
                    continue;
                }

                Vector3 force = new Vector3(target.Direction.x, 0, target.Direction.y) * effect.EffectValue;

                target.Rigidbody.AddForce(force, ForceMode.Impulse);
                effect.isApplied = true;
            }
        }
    }
}