using System.Collections.Generic;
using _Project.Code.Gameplay.Features.Ability.Configs;
using _Project.Code.Gameplay.Features.Status.Configs;
using _Project.Code.Infrastructure.View;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Character.Configs
{
    [CreateAssetMenu(menuName = "Fragile Mare/Configs/Character", fileName = "CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        public float speed;
        public float sprintSpeed;
        public float dashSpeed;
        public float dashDuration;
        public int dashMaxCount;
        public float dashRegenDuration;
        public int dashRegenAmount;
        public float maxEnergy;
        public float currentEnergy;
        public float energyToRegen;
        public EntityBehaviour prefab;

        public List<AbilityConfig> abilities;
        public List<StatusConfig> statuses;
    }
}