using _Project.Code.Gameplay.Cameras.Providers;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Movement.Move.Systems
{
    public class DirectionCharacterMoveSystem : IExecuteSystem
    {
        private readonly ICameraProvider _camera;
        private readonly IGroup<GameEntity> _characters;
        private readonly IGroup<GameEntity> _inputs;

        public DirectionCharacterMoveSystem(GameContext game, ICameraProvider camera)
        {
            _camera = camera;
            _characters = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Character,
                GameMatcher.Direction
            ));

            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.InputMovementAxis
            ));
        }

        public void Execute()
        {
            foreach (GameEntity character in _characters)
            {
                foreach (GameEntity input in _inputs)
                {
                    float verticalInput = input.InputMovementAxis.y;
                    float horizontalInput = input.InputMovementAxis.x;

                    Vector2 direction = Vector2.zero;

                    var cameraPosition = _camera.GetCameraForwardXZ();

                    if (verticalInput > 0)
                        direction += new Vector2(cameraPosition.x, cameraPosition.z).normalized;
                    else if (verticalInput < 0)
                        direction += new Vector2(-cameraPosition.x, -cameraPosition.z).normalized;

                    if (horizontalInput > 0)
                        direction += new Vector2(cameraPosition.z, -cameraPosition.x).normalized;
                    else if (horizontalInput < 0)
                        direction += new Vector2(-cameraPosition.z, cameraPosition.x).normalized;

                    character.ReplaceDirection(direction);
                }
            }
        }
    }
}