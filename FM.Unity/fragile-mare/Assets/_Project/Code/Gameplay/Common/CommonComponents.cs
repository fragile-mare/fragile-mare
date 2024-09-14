using _Project.Code.Infrastructure.View;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Common
{
    [Game] public class Id : IComponent { public int Value; }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class WorldRotation : IComponent { public Quaternion Value; }
    [Game] public class TransformComponent : IComponent { public Transform Value; }
    [Game] public class View: IComponent { public IEntityView Value; }
    [Game] public class ViewPath: IComponent { public string Value; }
    [Game] public class ViewPrefab: IComponent { public EntityBehaviour Value; }
    [Game] public class Destructed: IComponent { }
    [Game] public class SelfDestructTimer: IComponent { public float Value; }
}