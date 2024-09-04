//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDashMaxCount;

    public static Entitas.IMatcher<GameEntity> DashMaxCount {
        get {
            if (_matcherDashMaxCount == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DashMaxCount);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDashMaxCount = matcher;
            }

            return _matcherDashMaxCount;
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

    public _Project.Code.Gameplay.Features.Movement.Dash.DashMaxCount dashMaxCount { get { return (_Project.Code.Gameplay.Features.Movement.Dash.DashMaxCount)GetComponent(GameComponentsLookup.DashMaxCount); } }
    public int DashMaxCount { get { return dashMaxCount.Value; } }
    public bool hasDashMaxCount { get { return HasComponent(GameComponentsLookup.DashMaxCount); } }

    public GameEntity AddDashMaxCount(int newValue) {
        var index = GameComponentsLookup.DashMaxCount;
        var component = (_Project.Code.Gameplay.Features.Movement.Dash.DashMaxCount)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashMaxCount));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceDashMaxCount(int newValue) {
        var index = GameComponentsLookup.DashMaxCount;
        var component = (_Project.Code.Gameplay.Features.Movement.Dash.DashMaxCount)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashMaxCount));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveDashMaxCount() {
        RemoveComponent(GameComponentsLookup.DashMaxCount);
        return this;
    }
}
