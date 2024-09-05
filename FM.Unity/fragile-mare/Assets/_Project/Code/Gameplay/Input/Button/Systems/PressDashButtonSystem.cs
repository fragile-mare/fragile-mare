﻿using _Project.Code.Gameplay.Input.Button.Services;
using Entitas;

namespace _Project.Code.Gameplay.Input.Button.Systems
{
    public class PressDashButtonSystem : IExecuteSystem
    {
        private readonly IInputButtonService _inputService;
        private readonly IGroup<GameEntity> _inputs;

        public PressDashButtonSystem(GameContext game, IInputButtonService inputService)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (var input in _inputs)
            {
                input.isDashButtonPressed = _inputService.IsDashPressed();
            }
        }
    }
}