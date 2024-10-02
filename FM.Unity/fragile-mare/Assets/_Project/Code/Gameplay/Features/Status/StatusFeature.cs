using _Project.Code.Gameplay.Features.Status.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Status
{
    public sealed class StatusFeature : Feature
    {
        public StatusFeature(ISystemsFactory systems)
        {
            Add(systems.Create<StatusDurationSystem>());

            Add(systems.Create<DestructExpiredStatusCleanupSystem>());
        }
    }
}