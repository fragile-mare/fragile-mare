using _Project.Code.Gameplay.Features.Character.Configs;

namespace _Project.Code.Common.Services.StaticData
{
    public interface IStaticDataService
    {
        public CharacterConfig CharacterConfig { get; }
        void LoadAll();
    }
}