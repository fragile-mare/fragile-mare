using System;
using _Project.Code.Common.Extensions;
using _Project.Code.Gameplay.Features.Ability.Builders;

namespace _Project.Code.Gameplay.Features.Physics.RelativePush.Abilities
{
    [Serializable]
    public class SphereRelativePushAbilityBuilder : DefaultAbilityBuilder
    {
        public override GameEntity Build()
        {
            return base
                .Build()
                .With(e => e.isSphereRelativePushAbility = true);
        }
    }
}