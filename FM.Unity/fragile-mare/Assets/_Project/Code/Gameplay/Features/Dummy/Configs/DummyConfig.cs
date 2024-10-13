using System.Collections.Generic;
using _Project.Code.Gameplay.Features.Ability.Configs;
using _Project.Code.Infrastructure.CustomUnity;
using _Project.Code.Infrastructure.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Code.Gameplay.Features.Dummy.Configs
{
    [CreateAssetMenu(menuName = "Fragile Mare/Configs/Dummy", fileName = "DummyConfig")]
    public class DummyConfig : ScriptableObject
    {
        public EntityBehaviour prefab;
        public Vector3 at;
        public List<AbilityConfig> abilities;
    }
}