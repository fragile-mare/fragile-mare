using System.Collections.Generic;
using _Project.Code.Gameplay.Features.Character.Configs;
using _Project.Code.Gameplay.Features.Dummy.Configs;
using _Project.Code.Gameplay.Input.Configs;

namespace _Project.Code.Common.Services.StaticData
{
    public interface IStaticDataService
    {
        CharacterConfig CharacterConfig { get; }
        IReadOnlyList<DummyConfig> DummiesConfigs { get; }
        InputConfig InputConfig { get; }
        void LoadAll();
    }
}