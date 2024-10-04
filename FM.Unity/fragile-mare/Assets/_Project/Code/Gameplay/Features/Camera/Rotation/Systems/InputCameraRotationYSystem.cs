using _Project.Code.Gameplay.Cameras.Providers;
using Entitas;

namespace _Project.Code.Gameplay.Features.Camera.Rotation.Systems
{
    public class InputCameraRotationYSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputs;
        private readonly ICameraProvider _camera;
        
        public InputCameraRotationYSystem(GameContext game, ICameraProvider camera)
        {
            _camera = camera;
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.XRotationCursor
            ));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                _camera.SetCameraRotationY(input.XRotationCursor);
            }
        }
    }
}