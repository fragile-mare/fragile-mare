using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Movement
{
    [Game] public class Direction : IComponent { public Vector2 Value; }

    [Game] public class Speed : IComponent { public float Value; }
    [Game] public class Moving : IComponent { }
    
    [Game] public class CanSprint : IComponent { }
    [Game] public class Sprinting : IComponent { }
    [Game] public class SprintSpeed : IComponent { public float Value; }
}