using System.Collections.Generic;
using System.Linq;
using _Project.Code.Gameplay.Features.Character.Configs;
using _Project.Code.Gameplay.Features.Dummy.Configs;
using _Project.Code.Gameplay.Input.Configs;
using _Project.Code.Gameplay.Input.Controls;
using _Project.Code.Gameplay.Input.Controls.Actions;
using _Project.Code.Infrastructure;
using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Code.Common.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private CharacterConfig _characterConfig;
        private List<DummyConfig> _dummiesConfigs;
        private InputConfig _inputConfig;
        public CharacterConfig CharacterConfig => _characterConfig;
        public IReadOnlyList<DummyConfig> DummiesConfigs => _dummiesConfigs;
        public InputConfig InputConfig => _inputConfig;

        public void LoadAll()
        {
            LoadCharacterConfig();
            LoadInputConfig();
        }

        private void LoadCharacterConfig()
        {
            _characterConfig = Resources.Load<CharacterConfig>("Character/CharacterConfig");
            _dummiesConfigs = Resources.LoadAll<DummyConfig>("Dummy").ToList();
        }

        private void LoadInputConfig()
        {
            _inputConfig = Resources.Load<InputConfig>("Input/InputConfig");
        }
    }
}