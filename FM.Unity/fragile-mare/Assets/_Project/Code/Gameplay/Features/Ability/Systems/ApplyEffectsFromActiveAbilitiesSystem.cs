﻿using _Project.Code.Gameplay.Features.Effect.Configs;
using _Project.Code.Gameplay.Features.Effect.Factories;
using Entitas;

namespace _Project.Code.Gameplay.Features.Ability.Systems
{
    public class ApplyEffectsFromActiveAbilitiesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IEffectFactory _effectFactory;

        public ApplyEffectsFromActiveAbilitiesSystem(GameContext game, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Ability,
                    GameMatcher.Applied,
                    GameMatcher.HolderId,
                    GameMatcher.TargetBuffer,
                    GameMatcher.EffectList));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities)
            foreach (int targetId in ability.TargetBuffer)
            foreach (EffectSetup effectSetup in ability.EffectList)
            {
                _effectFactory.CreateEffect(effectSetup, targetId, ability.HolderId);
            }
        }
    }
}