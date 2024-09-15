using _Project.Code.Infrastructure.Systems;
using _Project.Code.Infrastructure.View.Services;

namespace _Project.Code.Infrastructure.View
{
    public class EntityViewFeature : Feature
    {
        public EntityViewFeature(ISystemsFactory systems)
        {
            Add(systems.Create<BindEntityViewFromPathSystem>());
            Add(systems.Create<BindEntityViewFromPrefabSystem>());
        }
    }
}