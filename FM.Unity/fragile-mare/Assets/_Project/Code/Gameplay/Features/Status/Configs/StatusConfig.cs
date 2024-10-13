using System.Collections.Generic;
using _Project.Code.Gameplay.Features.Physics.Acceleration.Statuses;
using _Project.Code.Gameplay.Features.Physics.RelativePush.Statuses;
using _Project.Code.Gameplay.Features.Status.Builders;
using _Project.Code.Gameplay.Features.Status.Factories;
using _Project.Code.Infrastructure.CustomUnity;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Status.Configs
{
    [CreateAssetMenu(menuName = "Fragile Mare/Configs/Status", fileName = "StatusConfig")]
    public class StatusConfig : ScriptableObject
    {
        public CustomUnityEnum<IStatusBuilder> status = new()
        {
            values = new List<IStatusBuilder>
            {
                new AccelerationStatusBuilder(),
                new AccelerationInputStatusBuilder(),
                new SphereRelativePushStatusBuilder()
            }
        };
    }
}