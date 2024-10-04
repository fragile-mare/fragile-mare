using _Project.Code.Gameplay.Cameras.Providers;
using Entitas;

namespace _Project.Code.Gameplay.Features.Camera.Rotation.Systems
{
    public class InputCameraRotationXSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputs;
        private readonly ICameraProvider _camera;
        
        public InputCameraRotationXSystem(GameContext game, ICameraProvider camera)
        {
            _camera = camera;
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.YRotationCursor
            ));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                _camera.SetCameraRotationX(-input.YRotationCursor);
            }
        }
    }
}