using _Project.Code.Gameplay.Features.Dummy.Configs;

namespace _Project.Code.Gameplay.Features.Dummy.Factory
{
    public interface IDummyFactory
    {
        GameEntity CreateDummy(DummyConfig dummyConfig);
    }
}