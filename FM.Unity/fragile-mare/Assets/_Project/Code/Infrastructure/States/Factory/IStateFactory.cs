using _Project.Code.Infrastructure.States.GameStates;

namespace _Project.Code.Infrastructure.States.Factory
{
    public interface IStateFactory
    {
        TState GetState<TState>() where TState : IState;
    }
}