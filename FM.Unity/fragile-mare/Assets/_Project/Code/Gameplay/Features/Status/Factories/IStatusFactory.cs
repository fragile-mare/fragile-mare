using _Project.Code.Gameplay.Features.Status.Builders;

namespace _Project.Code.Gameplay.Features.Status.Factories
{
    public interface IStatusFactory
    {
        public GameEntity CreateStatus<TBuilder>(TBuilder builder, int targetId, int producerId)
            where TBuilder : IStatusBuilder;
    }
}