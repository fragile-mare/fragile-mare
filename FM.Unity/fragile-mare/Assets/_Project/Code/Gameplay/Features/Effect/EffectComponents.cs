using Entitas;

namespace _Project.Code.Gameplay.Features.Effect
{
    [Game]
    public class Effect : IComponent
    {
    }

    [Game]
    public class EffectTypeId : IComponent
    {
        public EffectType Value;
    }

    [Game]
    public class EffectValue : IComponent
    {
        public float Value;
    }

    [Game]
    public class TargetId : IComponent
    {
        public int Value;
    }

    [Game]
    public class ProducerId : IComponent
    {
        public int Value;
    }

    [Game]
    public class ImpulseEffect : IComponent
    {
    }

    [Game]
    public class DashEffect : IComponent
    {
    }

    [Game]
    public class Applied : IComponent
    {
    }
}