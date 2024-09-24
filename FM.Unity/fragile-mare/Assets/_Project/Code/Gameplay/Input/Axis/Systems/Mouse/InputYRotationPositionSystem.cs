using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Axis.Systems.Mouse
{
    public class InputYRotationPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputs;
        
        public InputYRotationPositionSystem(GameContext game)
        {
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.YRotationCursor,
                GameMatcher.CursorX
            ));
        }
        
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                input.ReplaceYRotationCursor(input.YRotationCursor + input.CursorX);
                input.ReplaceYRotationCursor(Mathf.Clamp(input.YRotationCursor, -90f, 90f));
            }
        }
    }
}