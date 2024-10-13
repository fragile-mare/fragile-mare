using System.Collections.Generic;
using _Project.Code.Gameplay.Features.Effect.Configs;
using _Project.Code.Gameplay.Features.Status.Configs;
using _Project.Code.Infrastructure.CustomUnity;
using Entitas;

namespace _Project.Code.Gameplay.Features.Ability
{
    public class AbilityComponents
    {
        [Game]
        public class Ability : IComponent { }

        [Game]
        public class Ready : IComponent { }

        [Game]
        public class HolderId : IComponent { public int Value; }

        [Game]
        public class CooldownInterval : IComponent { public float Value; }

        [Game]
        public class CooldownTimer : IComponent { public float Value; }

        [Game]
        public class StatusList : IComponent { public List<StatusConfig> Value; }

        [Game]
        public class EffectList : IComponent { public List<EffectConfig> Value; }

        [Game]
        public class TargetBuffer : IComponent { public List<int> Value; }
    }
}