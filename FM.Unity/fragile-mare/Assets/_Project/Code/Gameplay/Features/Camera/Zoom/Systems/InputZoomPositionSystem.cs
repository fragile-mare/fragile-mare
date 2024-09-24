using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Camera.Zoom.Systems
{
    public class InputZoomPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _input;

        public InputZoomPositionSystem(GameContext game)
        {
            _input = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.Offset,
                GameMatcher.Zoom,
                GameMatcher.ZoomMin,
                GameMatcher.ZoomMax,
                GameMatcher.MouseScrollWheel
            ));
        }

        public void Execute()
        {
            foreach (GameEntity input in _input)
            {
                Vector3 currentOffset = input.Offset;
       
                if (input.MouseScrollWheel > 0)
                {
                    currentOffset.z += input.Zoom;
                }
                else if (input.MouseScrollWheel < 0)
                {
                    currentOffset.z -= input.Zoom;

                }

                currentOffset.z = Mathf.Clamp(currentOffset.z, -Mathf.Abs(input.ZoomMax), -Mathf.Abs(input.ZoomMin));
                input.ReplaceOffset(currentOffset);
            }
        }
    }
}