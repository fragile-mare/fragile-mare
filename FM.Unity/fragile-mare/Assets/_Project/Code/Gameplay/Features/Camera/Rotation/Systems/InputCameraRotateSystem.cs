using _Project.Code.Gameplay.Cameras.Providers;
using Entitas;

namespace _Project.Code.Gameplay.Features.Camera.Rotation.Systems
{
    public class InputCameraRotateSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputs;
        private readonly IGroup<GameEntity> _character;
        private readonly ICameraProvider _camera;
        
        public InputCameraRotateSystem(GameContext game, ICameraProvider camera)
        {
            _camera = camera;
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.Offset
            ));
            
            _character = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Character,
                GameMatcher.WorldPosition
            ));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            foreach (GameEntity character in _character)
            {
                var position = _camera.GetLocalRotation() * input.Offset + character.WorldPosition;
                _camera.SetPosition(position);
            }
        }
    }
}