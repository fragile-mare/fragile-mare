﻿using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Physics
{
    [Game] public class RigidbodyComponent : IComponent { public Rigidbody Value; }
    [Game] public class Velocity : IComponent { public Vector3 Value; }

    [Game] public class ForceMovePosition : IComponent { }
}