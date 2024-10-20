using System.Collections.Generic;
using _Project.Code.Gameplay.Features.Effect.Builders;
using _Project.Code.Gameplay.Features.Physics.Impulse.Effects;
using _Project.Code.Infrastructure.CustomUnity;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Effect.Configs
{
    [CreateAssetMenu(menuName = "Fragile Mare/Configs/Effect", fileName = "EffectConfig")]
    public class EffectConfig : ScriptableObject
    {
        public CustomUnityEnum<IEffectBuilder> effect = new()
        {
            values = new List<IEffectBuilder>
            {
                new ImpulseEffectBuilder()
            }
        };
    }
}