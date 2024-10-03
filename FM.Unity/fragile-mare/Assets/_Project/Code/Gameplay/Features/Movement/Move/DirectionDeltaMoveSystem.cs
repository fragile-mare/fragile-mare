using _Project.Code.Common.Services.Time;
using _Project.Code.Gameplay.Cameras.Providers;
using _Project.Code.Gameplay.Input.Axis.Services;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Movement.Move
{
    public class DirectionDeltaMoveSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly ICameraProvider _camera;
        private readonly IGroup<GameEntity> _movers;
        private readonly IGroup<GameEntity> _inputs;

        public DirectionDeltaMoveSystem(GameContext game, ITimeService time, ICameraProvider camera)
        {
            _time = time;
            _camera = camera;
            _movers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.CanMove,
                GameMatcher.Moving,
                GameMatcher.WorldPosition,
                GameMatcher.Speed,
                GameMatcher.Direction
            ));
            
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.InputMovementAxis
            ));
        }
        
        public void Execute()
        {
            foreach (GameEntity mover in _movers)
            {
                foreach (GameEntity input in _inputs)
                {
                    float verticalInput = input.InputMovementAxis.y;
                    float horizontalInput = input.InputMovementAxis.x;

                    Vector2 direction = Vector2.zero;

                    var cameraPosition = _camera.GetCameraPositionXZ();
                
                    if (verticalInput > 0)
                        direction += new Vector2(cameraPosition.x, cameraPosition.z).normalized;
                    else if (verticalInput < 0)
                        direction += new Vector2(-cameraPosition.x, -cameraPosition.z).normalized; 
                
                    if (horizontalInput > 0)
                        direction += new Vector2(cameraPosition.z, -cameraPosition.x).normalized; 
                    else if (horizontalInput < 0)
                        direction += new Vector2(-cameraPosition.z, cameraPosition.x).normalized; 
                    
                    mover.ReplaceDirection(direction);
                    var worldDirection = new Vector3(mover.Direction.x, 0, mover.Direction.y);
                    mover.ReplaceWorldPosition(mover.WorldPosition +
                                                   worldDirection.normalized * mover.Speed * _time.DeltaTime);
                    
                }
            }
        }
    }
}