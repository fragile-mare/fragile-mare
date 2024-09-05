namespace _Project.Code.Infrastructure.States
{
    public interface IStateFactory
    {
        TState GetState<TState>() where TState : IState;
    }
}