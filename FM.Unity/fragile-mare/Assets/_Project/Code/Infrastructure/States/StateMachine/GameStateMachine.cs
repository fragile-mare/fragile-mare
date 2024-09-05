using _Project.Code.Infrastructure.States.Factory;
using _Project.Code.Infrastructure.States.GameStates;

namespace _Project.Code.Infrastructure.States.StateMachine
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