using _Project.Code.Gameplay.Features.Character.Factory;
using Entitas;

namespace _Project.Code.Gameplay.Features.Character.Systems
{
    public class InitializeCharacterSystem : IInitializeSystem, ITearDownSystem
    {
        private readonly ICharacterFactory _characterFactory;
        private readonly ILevelDataProvider _levelData;
        private GameEntity _character;

        public InitializeCharacterSystem(ICharacterFactory characterFactory, ILevelDataProvider levelData)
        {
            _characterFactory = characterFactory;
            _levelData = levelData;
        }

        public void Initialize()
        {
            _character = _characterFactory.CreateCharacter(_levelData.StartPoint, _levelData.StartRotation);
        }

        public void TearDown()
        {
            _character.isDestructed = true;
        }
    }
}