using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _Project.Code.Gameplay.Features.Effect
{
    [Game] public class Effect : IComponent { }
    [Game] public class EffectValue : IComponent { public float Value; }
    [Game] public class TargetId : IComponent { [EntityIndex] public int Value; }
    [Game] public class ProducerId : IComponent { [EntityIndex] public int Value; }
    [Game] public class Applied : IComponent { }
}