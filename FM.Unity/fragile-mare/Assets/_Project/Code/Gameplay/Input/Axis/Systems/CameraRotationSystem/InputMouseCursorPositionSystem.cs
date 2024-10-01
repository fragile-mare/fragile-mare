using _Project.Code.Gameplay.Input.Axis.Services.Mouse;
using Entitas;

namespace _Project.Code.Gameplay.Input.Axis.Systems.CameraRotationSystem
{
    public class InputMouseCursorPositionSystem : IExecuteSystem
    {
        private readonly ICursorPositionService _mouse;
        private readonly IGroup<GameEntity> _inputs;
        
        public InputMouseCursorPositionSystem(GameContext game, ICursorPositionService mouse)
        {
            _mouse = mouse;
            
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.CursorX,
                GameMatcher.CursorY
            ));
        }
        
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                input.ReplaceCursorX(_mouse.GetCursorPosition().x);
                input.ReplaceCursorY(_mouse.GetCursorPosition().y);
            }
        }
    }
}