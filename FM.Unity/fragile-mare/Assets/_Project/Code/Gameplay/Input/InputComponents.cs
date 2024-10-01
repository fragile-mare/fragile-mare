using Entitas;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace _Project.Code.Gameplay.Input
{
    [Game] public class Input : IComponent { }
    [Game] public class InputMovementAxis : IComponent { public Vector2 Value; }
    
    [Game] public class SprintButtonPressed : IComponent { }
    [Game] public class DashButtonPressed : IComponent { }
    [Game] public class InputCursorAxis : IComponent { }
    [Game] public class MouseSens : IComponent { public float Value; }
    [Game] public class XRotationCursor : IComponent { public float Value; }
    [Game] public class YRotationCursor : IComponent { public float Value; }
    [Game] public class CursorX : IComponent { public float Value; }
    [Game] public class CursorY : IComponent { public float Value; }
    [Game] public class Zoom : IComponent { public float Value; }
    [Game] public class ZoomMin : IComponent { public float Value; }
    [Game] public class ZoomMax : IComponent { public float Value; }
    [Game] public class LimitRotationY : IComponent { public float Value; }
    [Game] public class Offset : IComponent { public Vector3 Value; }
    [Game] public class MouseScrollWheel : IComponent { public float Value; }
    [Game] public class CameraOffsetInitialized : IComponent { }
}