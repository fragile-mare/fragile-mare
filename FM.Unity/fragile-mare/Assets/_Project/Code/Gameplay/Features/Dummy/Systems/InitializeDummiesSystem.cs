using _Project.Code.Common.Services.StaticData;
using _Project.Code.Gameplay.Features.Character.Factory;
using _Project.Code.Gameplay.Features.Dummy.Configs;
using _Project.Code.Gameplay.Features.Dummy.Factory;
using Entitas;

namespace _Project.Code.Gameplay.Features.Dummy.Systems
{
    public class InitializeDummiesSystem : IInitializeSystem, ITearDownSystem
    {
        private readonly ICharacterFactory _characterFactory;
        private readonly IGroup<GameEntity> _dummies;
        private readonly IDummyFactory _dummyFactory;
        private readonly IStaticDataService _staticData;

        public InitializeDummiesSystem(GameContext game, IDummyFactory dummyFactory, IStaticDataService staticData)
        {
            _dummyFactory = dummyFactory;
            _staticData = staticData;

            _dummies = game.GetGroup(GameMatcher.Dummy);
        }

        public void Initialize()
        {
            foreach (DummyConfig dummyConfig in _staticData.DummiesConfigs)
            {
                _dummyFactory.CreateDummy(dummyConfig);
            }
        }

        public void TearDown()
        {
            foreach (GameEntity dummy in _dummies)
            {
                dummy.isDestructed = true;
            }
        }
    }
}