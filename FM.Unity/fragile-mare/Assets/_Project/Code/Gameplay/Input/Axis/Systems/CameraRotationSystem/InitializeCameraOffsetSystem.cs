using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Axis.Systems.CameraRotationSystem
{
    public class InitializeCameraOffsetSystem : IInitializeSystem
    {
        private readonly IGroup<GameEntity> _inputs;

        public InitializeCameraOffsetSystem(GameContext game)
        {
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.LimitRotationY,
                GameMatcher.Offset,
                GameMatcher.ZoomMax));
        }

        public void Initialize()
        {
            foreach (var input in _inputs)
            {
                input.ReplaceLimitRotationY(Mathf.Abs(input.LimitRotationY));

                if (input.LimitRotationY > 90) input.ReplaceLimitRotationY(90);

                input.ReplaceOffset(new Vector3(input.Offset.x, input.Offset.y,
                    -Mathf.Abs(input.ZoomMax) / 2));
            }
        }
    }
}