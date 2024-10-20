using Entitas;

namespace _Project.Code.Gameplay.Features.Movement.Sprint
{
    [Game] public class CanSprint : IComponent { }
    [Game] public class Sprinting : IComponent { }
    [Game] public class SprintSpeed : IComponent { public float Value; }
}