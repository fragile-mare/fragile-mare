using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Axis.Systems.Mouse
{
    public class InputXRotationPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputs;
        
        public InputXRotationPositionSystem(GameContext game)
        {
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.XRotationCursor,
                GameMatcher.CursorY
            ));
        }
        
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                input.ReplaceXRotationCursor(input.XRotationCursor - input.CursorY);
                input.ReplaceXRotationCursor(Mathf.Clamp(input.XRotationCursor, -90f, 90f));
            }
        }
    }
}