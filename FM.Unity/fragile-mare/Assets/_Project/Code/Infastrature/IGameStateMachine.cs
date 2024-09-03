namespace _Project.Code.Infastrature
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
    }
}