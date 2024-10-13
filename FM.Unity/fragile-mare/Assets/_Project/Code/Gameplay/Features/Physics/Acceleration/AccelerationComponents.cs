using Entitas;

namespace _Project.Code.Gameplay.Features.Physics.Acceleration
{
    public class AccelerationComponents
    {
        [Game]
        public class AccelerationStatus : IComponent { }

        [Game]
        public class InputAccelerationStatus : IComponent { }
    }
}