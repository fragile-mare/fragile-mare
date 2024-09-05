using Entitas;

namespace _Project.Code.Infrastructure.Systems
{
    public interface ISystemsFactory
    {
        TSystem Create<TSystem>() where TSystem : ISystem;
        TSystem Create<TSystem>(params object[] args) where TSystem : ISystem;
    }
}