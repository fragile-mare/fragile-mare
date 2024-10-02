using System.Collections.Generic;
using _Project.Code.Gameplay.Features.Effect.Configs;
using _Project.Code.Gameplay.Features.Status.Configs;
using Entitas;

namespace _Project.Code.Gameplay.Features.Ability
{
    public partial class AbilityComponents
    {
        [Game]
        public class Ability : IComponent
        {
        }

        [Game]
        public class Ready : IComponent
        {
        }

        [Game]
        public class AbilityTypeComponent : IComponent
        {
            public AbilityType Value;
        }

        [Game]
        public class DashAbility : IComponent
        {
        }

        [Game]
        public class SphereRelativePushAbility : IComponent
        {
        }

        [Game]
        public class HolderId : IComponent
        {
            public int Value;
        }

        [Game]
        public class CooldownInterval : IComponent
        {
            public float Value;
        }

        [Game]
        public class CooldownTimer : IComponent
        {
            public float Value;
        }

        [Game]
        public class StatusList : IComponent
        {
            public List<StatusSetup> Value;
        }

        [Game]
        public class EffectList : IComponent
        {
            public List<EffectSetup> Value;
        }

        [Game]
        public class TargetBuffer : IComponent
        {
            public List<int> Value;
        }
    }
}