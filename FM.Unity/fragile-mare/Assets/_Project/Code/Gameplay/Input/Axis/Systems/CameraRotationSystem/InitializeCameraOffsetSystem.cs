using System.Collections.Generic;
using _Project.Code.Common.Extensions;
using _Project.Code.Gameplay.Cameras.Providers;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Axis.Systems.CameraRotationSystem
{
    public class InitializeCameraOffsetSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(64);

        private readonly IGroup<GameEntity> _characters;
        private readonly IGroup<GameEntity> _inputs;
        private readonly ICameraProvider _camera;

        public InitializeCameraOffsetSystem(GameContext game, ICameraProvider camera)
        {
            _camera = camera;

            _characters = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Character,
                GameMatcher.WorldPosition
            ));

            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.LimitRotationY,
                GameMatcher.Offset,
                GameMatcher.ZoomMax
            ).NoneOf(GameMatcher.CameraOffsetInitialized));
        }

        public void Execute()
        {
            foreach (var input in _inputs.GetEntities(_buffer))
            {
                foreach (var character in _characters)
                {
                    input.ReplaceLimitRotationY(Mathf.Abs(input.LimitRotationY));

                    if (input.LimitRotationY > 90) input.ReplaceLimitRotationY(90);

                    input.ReplaceOffset(new Vector3(input.Offset.x, input.Offset.y,
                        -Mathf.Abs(input.ZoomMax) / 2));

                    var position = character.WorldPosition + input.Offset;
                    _camera.SetPosition(position);

                    input.With(x => x.isCameraOffsetInitialized = true);
                }
            }
        }
    }
}