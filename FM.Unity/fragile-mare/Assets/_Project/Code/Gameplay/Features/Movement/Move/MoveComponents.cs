using Entitas;

namespace _Project.Code.Gameplay.Features.Movement.Move
{
    [Game] public class CanMove : IComponent { }
    [Game] public class Moving : IComponent { }
    [Game] public class Speed : IComponent { public float Value; }
}