//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDashRegenDuration;

    public static Entitas.IMatcher<GameEntity> DashRegenDuration {
        get {
            if (_matcherDashRegenDuration == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DashRegenDuration);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDashRegenDuration = matcher;
            }

            return _matcherDashRegenDuration;
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

    public _Project.Code.Gameplay.Features.Movement.Dash.DashRegenDuration dashRegenDuration { get { return (_Project.Code.Gameplay.Features.Movement.Dash.DashRegenDuration)GetComponent(GameComponentsLookup.DashRegenDuration); } }
    public float DashRegenDuration { get { return dashRegenDuration.Value; } }
    public bool hasDashRegenDuration { get { return HasComponent(GameComponentsLookup.DashRegenDuration); } }

    public GameEntity AddDashRegenDuration(float newValue) {
        var index = GameComponentsLookup.DashRegenDuration;
        var component = (_Project.Code.Gameplay.Features.Movement.Dash.DashRegenDuration)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashRegenDuration));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceDashRegenDuration(float newValue) {
        var index = GameComponentsLookup.DashRegenDuration;
        var component = (_Project.Code.Gameplay.Features.Movement.Dash.DashRegenDuration)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashRegenDuration));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveDashRegenDuration() {
        RemoveComponent(GameComponentsLookup.DashRegenDuration);
        return this;
    }
}
