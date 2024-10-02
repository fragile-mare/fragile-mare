using _Project.Code.Gameplay.Features.Status.Configs;

namespace _Project.Code.Gameplay.Features.Status.Factories
{
    public interface IStatusFactory
    {
        GameEntity CreateStatus(StatusSetup statusSetup, int targetId, int producerId);
    }
}