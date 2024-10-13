using System;
using System.Collections.Generic;
using _Project.Code.Common.Entity;
using _Project.Code.Gameplay.Features.Effect.Configs;
using _Project.Code.Gameplay.Features.Status.Configs;

namespace _Project.Code.Gameplay.Features.Ability.Builders
{
    [Serializable]
    public class DefaultAbilityBuilder : IAbilityBuilder
    {
        public float cooldown;
        public List<StatusConfig> statuses;
        public List<EffectConfig> effects;
        
        public virtual GameEntity Build()
        {
            return CreateEntity.Empty()
                .AddStatusList(statuses)
                .AddEffectList(effects)
                .AddCooldownInterval(cooldown)
                .AddCooldownTimer(0);
        }
    }
}