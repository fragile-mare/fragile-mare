using _Project.Code.Gameplay.Features.Character.Configs;
using UnityEngine;

namespace _Project.Code.Common.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private CharacterConfig _characterConfig;
        public CharacterConfig CharacterConfig => _characterConfig;

        public void LoadAll()
        {
            LoadCharacterConfig();
        }

        private void LoadCharacterConfig()
        {
            _characterConfig = Resources.Load<CharacterConfig>("Character/characterConfig");
        }
    }
}