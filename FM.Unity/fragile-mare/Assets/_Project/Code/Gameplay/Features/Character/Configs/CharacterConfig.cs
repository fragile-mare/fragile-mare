using System;
using System.Collections.Generic;
using _Project.Code.Gameplay.Features.Ability.Configs;
using _Project.Code.Gameplay.Features.Status.Configs;
using _Project.Code.Infrastructure.CustomUnity;
using _Project.Code.Infrastructure.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Code.Gameplay.Features.Character.Configs
{
    [CreateAssetMenu(menuName = "Fragile Mare/Configs/Character", fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        public float speed;
        public float sprintSpeed;
        public float maxEnergy;
        public float currentEnergy;
        public float energyToRegen;
        public EntityBehaviour prefab;

        public List<AbilityConfig> abilities;
        public List<StatusConfig> statuses;
    }
}