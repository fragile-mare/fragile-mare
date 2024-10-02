using System.Collections.Generic;
using _Project.Code.Common.Extensions;
using _Project.Code.Gameplay.Cameras.Providers;
using Entitas;

namespace _Project.Code.Gameplay.Features.Camera.Rotation.Systems
{
    public class InitializeCameraPositionSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(64);

        private readonly IGroup<GameEntity> _characters;
        private readonly IGroup<GameEntity> _inputs;
        private readonly ICameraProvider _camera;

        public InitializeCameraPositionSystem(GameContext game, ICameraProvider camera)
        {
            _camera = camera;

            _characters = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Character,
                GameMatcher.WorldPosition
            ));

            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.Offset
            ).NoneOf(GameMatcher.CameraOffsetInitialized));
        }

        public void Execute()
        {
            foreach (var input in _inputs.GetEntities(_buffer))
            {
                foreach (var character in _characters)
                {
                    var position = character.WorldPosition + input.Offset;
                    _camera.SetPosition(position);

                    input.With(x => x.isCameraOffsetInitialized = true);
                }
            }
        }
    }
}