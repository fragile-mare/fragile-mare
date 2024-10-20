using System.Collections.Generic;
using _Project.Code.Gameplay.Features.Character.Configs;
using _Project.Code.Gameplay.Features.Dummy.Configs;

namespace _Project.Code.Common.Services.StaticData
{
    public interface IStaticDataService
    {
        public CharacterConfig CharacterConfig { get; }
        IReadOnlyList<DummyConfig> DummiesConfigs { get; }
        void LoadAll();
    }
}