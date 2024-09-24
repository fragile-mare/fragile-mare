using _Project.Code.Gameplay.Cameras.Providers;
using Entitas;

namespace _Project.Code.Gameplay.Input.Axis.Systems.Mouse
{
    public class InputCameraRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputs;
        private readonly ICameraProvider _camera;

        public InputCameraRotationSystem(GameContext game, ICameraProvider camera)
        {
            _camera = camera;
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.XRotationCursor,
                GameMatcher.YRotationCursor
            ));
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                _camera.SetRotation(input.XRotationCursor, input.YRotationCursor, 0f);
            }
        }
    }
}