namespace _Project.Code.Infrastructure.States
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}