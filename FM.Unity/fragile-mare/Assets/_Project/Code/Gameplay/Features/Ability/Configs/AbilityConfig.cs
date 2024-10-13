using System.Collections.Generic;
using _Project.Code.Gameplay.Features.Ability.Builders;
using _Project.Code.Gameplay.Features.Ability.Factories;
using _Project.Code.Gameplay.Features.Movement.Dash.Abilities;
using _Project.Code.Gameplay.Features.Physics.RelativePush.Abilities;
using _Project.Code.Infrastructure.CustomUnity;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Ability.Configs
{
    [CreateAssetMenu(menuName = "Fragile Mare/Configs/Ability", fileName = "AbilityConfig")]
    public class AbilityConfig : ScriptableObject
    {
        public CustomUnityEnum<IAbilityBuilder> ability = new()
        {
            values = new List<IAbilityBuilder>
            {
                new DashAbilityBuilder(),
                new SphereRelativePushAbilityBuilder()
            }
        };
    }
}