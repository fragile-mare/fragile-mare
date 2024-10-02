using _Project.Code.Gameplay.Cameras.Providers;
using Entitas;

namespace _Project.Code.Gameplay.Cameras.Systems
{
    public class CameraFollowCharacter : IExecuteSystem
    {
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _characters;
        private IExecuteSystem _executeSystemImplementation;

        public CameraFollowCharacter(GameContext game, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _characters = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Character,
                    GameMatcher.Rigidbody));
        }

        public void Execute()
        {
            foreach (var character in _characters)
            {
                _cameraProvider.SetWorldXZ(character.Rigidbody.position.x, character.Rigidbody.position.z);
            }
        }
    }
}