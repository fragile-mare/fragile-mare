using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Status
{
    [Game]
    public class Status : IComponent { }

    [Game]
    public class DurationTimer : IComponent { public float Value; }

    [Game]
    public class Expired : IComponent { }

    [Game]
    public class TargetVelocity : IComponent { public Vector3 Value; }

    [Game]
    public class DeltaAxis : IComponent { public Vector3 Value; }

    [Game]
    public class Radius : IComponent { public float Value; }
}