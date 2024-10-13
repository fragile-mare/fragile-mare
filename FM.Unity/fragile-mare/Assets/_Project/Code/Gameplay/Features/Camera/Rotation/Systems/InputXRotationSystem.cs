using _Project.Code.Gameplay.Cameras.Providers;
using Entitas;

namespace _Project.Code.Gameplay.Features.Camera.Rotation.Systems
{
    public class InputXRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputs;
        private readonly ICameraProvider _camera;
        
        public InputXRotationSystem(GameContext game, ICameraProvider camera)
        {
            _camera = camera;
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.CursorX,
                GameMatcher.XRotationCursor,
                GameMatcher.MouseSens
            ));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                input.ReplaceXRotationCursor(_camera.GetCameraLocalY() + input.CursorX * input.MouseSens);
            }
        }
    }
}