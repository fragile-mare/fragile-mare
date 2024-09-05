using System;
using System.Collections.Generic;

namespace _Project.Code.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly IStateFactory _stateFactory;
        private IState _activeState;

        public GameStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }
        
        public TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();

            TState state = _stateFactory.GetState<TState>();
            _activeState = state;

            return state;
        }
    }
}