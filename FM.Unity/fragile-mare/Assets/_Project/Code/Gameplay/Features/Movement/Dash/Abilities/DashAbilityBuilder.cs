using System;
using _Project.Code.Common.Extensions;
using _Project.Code.Gameplay.Features.Ability.Builders;

namespace _Project.Code.Gameplay.Features.Movement.Dash.Abilities
{
    [Serializable]
    public class DashAbilityBuilder : DefaultAbilityBuilder
    {
        public override GameEntity Build()
        {
            return base
                .Build()
                .With(e => e.isDashAbility = true);
        }
    }
}