//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDashDirection;

    public static Entitas.IMatcher<GameEntity> DashDirection {
        get {
            if (_matcherDashDirection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DashDirection);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDashDirection = matcher;
            }

            return _matcherDashDirection;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public _Project.Code.Gameplay.Features.Movement.Dash.DashDirection dashDirection { get { return (_Project.Code.Gameplay.Features.Movement.Dash.DashDirection)GetComponent(GameComponentsLookup.DashDirection); } }
    public UnityEngine.Vector2 DashDirection { get { return dashDirection.Value; } }
    public bool hasDashDirection { get { return HasComponent(GameComponentsLookup.DashDirection); } }

    public GameEntity AddDashDirection(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.DashDirection;
        var component = (_Project.Code.Gameplay.Features.Movement.Dash.DashDirection)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashDirection));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceDashDirection(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.DashDirection;
        var component = (_Project.Code.Gameplay.Features.Movement.Dash.DashDirection)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashDirection));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveDashDirection() {
        RemoveComponent(GameComponentsLookup.DashDirection);
        return this;
    }
}
