//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDashRegenAmountToApply;

    public static Entitas.IMatcher<GameEntity> DashRegenAmountToApply {
        get {
            if (_matcherDashRegenAmountToApply == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DashRegenAmountToApply);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDashRegenAmountToApply = matcher;
            }

            return _matcherDashRegenAmountToApply;
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

    public _Project.Code.Gameplay.Features.Movement.Dash.DashRegenAmountToApply dashRegenAmountToApply { get { return (_Project.Code.Gameplay.Features.Movement.Dash.DashRegenAmountToApply)GetComponent(GameComponentsLookup.DashRegenAmountToApply); } }
    public int DashRegenAmountToApply { get { return dashRegenAmountToApply.Value; } }
    public bool hasDashRegenAmountToApply { get { return HasComponent(GameComponentsLookup.DashRegenAmountToApply); } }

    public GameEntity AddDashRegenAmountToApply(int newValue) {
        var index = GameComponentsLookup.DashRegenAmountToApply;
        var component = (_Project.Code.Gameplay.Features.Movement.Dash.DashRegenAmountToApply)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashRegenAmountToApply));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceDashRegenAmountToApply(int newValue) {
        var index = GameComponentsLookup.DashRegenAmountToApply;
        var component = (_Project.Code.Gameplay.Features.Movement.Dash.DashRegenAmountToApply)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashRegenAmountToApply));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveDashRegenAmountToApply() {
        RemoveComponent(GameComponentsLookup.DashRegenAmountToApply);
        return this;
    }
}
