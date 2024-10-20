using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Movement.Dash
{
    [Game] public class CanDash : IComponent { }
    [Game] public class DashActivated : IComponent { }
    [Game] public class Dashing : IComponent { }
    [Game] public class DashDirection : IComponent { public Vector2 Value; }
    [Game] public class DashSpeed : IComponent { public float Value; }
    [Game] public class DashDuration : IComponent { public float Value; }
    [Game] public class DashTimer : IComponent { public float Value; }
    [Game] public class DashMaxCount : IComponent { public int Value; }
    [Game] public class DashCurrentCount : IComponent { public int Value; }
    [Game] public class DashRegenDuration : IComponent { public float Value; }
    [Game] public class DashRegenTimer : IComponent { public float Value; }
    [Game] public class DashRegenAmount : IComponent { public int Value; }
    [Game] public class DashRegenAmountToApply : IComponent { public int Value; }
}