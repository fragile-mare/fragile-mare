using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Axis.Systems.CameraRotationSystem
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
                input.ReplaceYRotationCursor(Mathf.Clamp(input.YRotationCursor + input.CursorY * input.MouseSens, -input.LimitRotationY, input.LimitRotationY));
            }
        }
    }
}