using System;
using System.Collections.Generic;
using _Project.Code.Gameplay.Features.Effect.Configs;
using _Project.Code.Gameplay.Features.Status.Configs;

namespace _Project.Code.Gameplay.Features.Ability.Configs
{
    [Serializable]
    public class AbilityConfig
    {
        public AbilityType type;
        public float cooldown;

        public List<StatusSetup> statuses;
        public List<EffectSetup> effects;
    }
}