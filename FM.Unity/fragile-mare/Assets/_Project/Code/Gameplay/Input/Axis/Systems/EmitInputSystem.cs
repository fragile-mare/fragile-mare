using _Project.Code.Gameplay.Input.Axis.Services;
using Entitas;

namespace _Project.Code.Gameplay.Input.Axis.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputAxisService _inputService;
        private readonly IGroup<GameEntity> _inputs;

        public EmitInputSystem(GameContext game, IInputAxisService inputService)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (var input in _inputs)
            {
                if (_inputService.HasAxisInput())
                {
                    input.ReplaceInputMovementAxis(_inputService.GetAxisInput());
                }
                else if (input.hasInputMovementAxis)
                {
                    input.RemoveInputMovementAxis();
                }
            }
        }
    }
}