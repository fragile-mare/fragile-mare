using _Project.Code.Common.Services.Time;
using _Project.Code.Gameplay.Input.Axis.Services;
using Entitas;

namespace _Project.Code.Gameplay.Input.Axis.Systems.Mouse
{
    public class InputCursorPositionSystem : IExecuteSystem
    {
        private readonly ICursorPositionService _mouse;
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _inputs;
        
        public InputCursorPositionSystem(GameContext game, ICursorPositionService mouse, ITimeService time)
        {
            _mouse = mouse;
            _time = time;
            
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.MouseSens,
                GameMatcher.CursorX,
                GameMatcher.CursorY
            ));
        }
        
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                input.ReplaceCursorX(_mouse.GetCursorPosition().x * input.MouseSens * _time.DeltaTime);
                input.ReplaceCursorY(_mouse.GetCursorPosition().y * input.MouseSens * _time.DeltaTime);
            }
        }
    }
}