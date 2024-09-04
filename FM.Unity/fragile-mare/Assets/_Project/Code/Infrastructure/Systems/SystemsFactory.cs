using Entitas;
using Zenject;

namespace _Project.Code.Infrastructure.Systems
{
    public class SystemsFactory : ISystemsFactory
    {
        private readonly DiContainer _container;

        public SystemsFactory(DiContainer container)
        {
            _container = container;
        }

        public TSystem Create<TSystem>() where TSystem : ISystem
        {
            return _container.Instantiate<TSystem>();
        }
        
        public TSystem Create<TSystem>(params object[] args) where TSystem : ISystem
        {
            return _container.Instantiate<TSystem>(args);
        }
    }
}