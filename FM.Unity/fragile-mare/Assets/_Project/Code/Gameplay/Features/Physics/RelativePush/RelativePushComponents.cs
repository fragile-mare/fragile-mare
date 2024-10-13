using Entitas;

namespace _Project.Code.Gameplay.Features.Physics.RelativePush
{
    public class RelativePushComponents
    {
        [Game]
        public class SphereRelativePushAbility : IComponent { }
        
        [Game]
        public class SphereRelativePushStatus : IComponent { }
    }
}