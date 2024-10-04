using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Camera.Rotation.Systems
{
    public class InputYRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputs;


        public InputYRotationSystem(GameContext game)
        {
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.CursorY,
                GameMatcher.LimitRotationY,
                GameMatcher.YRotationCursor,
                GameMatcher.MouseSens
            ));
        }

        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                input.ReplaceYRotationCursor(input.YRotationCursor + input.CursorY * input.MouseSens);
                input.ReplaceYRotationCursor(Mathf.Clamp(input.YRotationCursor, -input.LimitRotationY, input.LimitRotationY));
            }
        }
    }
}