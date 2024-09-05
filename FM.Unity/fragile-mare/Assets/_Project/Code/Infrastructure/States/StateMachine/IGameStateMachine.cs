using _Project.Code.Infrastructure.States.GameStates;

namespace _Project.Code.Infrastructure.States.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
    }
}