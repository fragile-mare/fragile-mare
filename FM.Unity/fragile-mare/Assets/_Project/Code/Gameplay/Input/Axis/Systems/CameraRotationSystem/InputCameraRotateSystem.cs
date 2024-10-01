using _Project.Code.Gameplay.Cameras.Providers;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Axis.Systems.CameraRotationSystem
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
                GameMatcher.XRotationCursor,
                GameMatcher.YRotationCursor
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
                _camera.SetCameraRotation(-input.YRotationCursor, input.XRotationCursor, 0);
                
                var position = character.WorldPosition + input.Offset;
                _camera.SetPosition(position);
            }
        }
    }
}