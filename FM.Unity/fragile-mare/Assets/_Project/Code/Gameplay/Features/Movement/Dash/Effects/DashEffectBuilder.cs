using System;
using _Project.Code.Common.Extensions;
using _Project.Code.Gameplay.Features.Effect.Builders;

namespace _Project.Code.Gameplay.Features.Movement.Dash.Effects
{
    [Serializable]
    public class DashEffectBuilder : DefaultEffectBuilder
    {
        public override GameEntity Build()
        {
            return base
                .Build()
                .With(e => e.isDashEffect = true);
        }
    }
}