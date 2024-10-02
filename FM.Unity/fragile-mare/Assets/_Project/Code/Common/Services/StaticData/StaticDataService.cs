using System.Collections.Generic;
using System.Linq;
using _Project.Code.Gameplay.Features.Character.Configs;
using _Project.Code.Gameplay.Features.Dummy.Configs;
using UnityEngine;

namespace _Project.Code.Common.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private CharacterConfig _characterConfig;
        private List<DummyConfig> _dummiesConfigs;
        public CharacterConfig CharacterConfig => _characterConfig;
        public IReadOnlyList<DummyConfig> DummiesConfigs => _dummiesConfigs;

        public void LoadAll()
        {
            LoadCharacterConfig();
        }

        private void LoadCharacterConfig()
        {
            _characterConfig = Resources.Load<CharacterConfig>("Character/characterConfig");
            _dummiesConfigs = Resources.LoadAll<DummyConfig>("Dummy").ToList();
        }
    }
}