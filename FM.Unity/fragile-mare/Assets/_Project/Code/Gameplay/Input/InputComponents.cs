using Entitas;
using Vector2 = UnityEngine.Vector2;

namespace _Project.Code.Gameplay.Input
{
    [Game] public class Input : IComponent { }
    [Game] public class InputMovementAxis : IComponent { public Vector2 Value; }
    
    [Game] public class SprintButtonPressed : IComponent { }
    [Game] public class DashButtonPressed : IComponent { }
    [Game] public class InputCursorAxis : IComponent { }
}