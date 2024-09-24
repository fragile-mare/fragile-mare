using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Camera.Rotation.Systems
{
    public class InitializeCameraOffsetSystem : IInitializeSystem
    {
        private readonly IGroup<GameEntity> _inputs;

        public InitializeCameraOffsetSystem(GameContext game)
        {
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.Offset,
                GameMatcher.LimitRotationY,
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