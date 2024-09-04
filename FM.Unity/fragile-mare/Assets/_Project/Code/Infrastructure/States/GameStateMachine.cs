using System;
using System.Collections.Generic;

namespace _Project.Code.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState()
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }
        
        public TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }
        
        public TState GetState<TState>() where TState : class, IState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}