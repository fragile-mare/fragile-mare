using Zenject;

namespace _Project.Code.Infrastructure.States
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container)
        {
            _container = container;
        }

        public TState GetState<TState>() where TState : IState
        {
            return _container.Resolve<TState>();
        }
    }
}