using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Effect.Systems
{
    public class ApplyImpulseEffectSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private readonly IGroup<GameEntity> _effects;
        private readonly IGroup<GameEntity> _targets;

        public ApplyImpulseEffectSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.ImpulseEffect,
                    GameMatcher.EffectValue,
                    GameMatcher.Direction3,
                    GameMatcher.TargetId)
                .NoneOf(GameMatcher.Applied));
            _targets = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Id,
                GameMatcher.Rigidbody));
        }

        public void Execute()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            foreach (var target in _targets)
            {
                if (effect.TargetId != target.Id)
                {
                    continue;
                }

                Vector3 force = effect.Direction3 * effect.EffectValue;

                target.Rigidbody.AddForce(force, ForceMode.Impulse);
                effect.isApplied = true;
            }
        }
    }
}