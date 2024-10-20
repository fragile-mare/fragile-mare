//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherStatusList;

    public static Entitas.IMatcher<GameEntity> StatusList {
        get {
            if (_matcherStatusList == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StatusList);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStatusList = matcher;
            }

            return _matcherStatusList;
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

    public _Project.Code.Gameplay.Features.Ability.AbilityComponents.StatusList statusList { get { return (_Project.Code.Gameplay.Features.Ability.AbilityComponents.StatusList)GetComponent(GameComponentsLookup.StatusList); } }
    public System.Collections.Generic.List<_Project.Code.Gameplay.Features.Status.Configs.StatusConfig> StatusList { get { return statusList.Value; } }
    public bool hasStatusList { get { return HasComponent(GameComponentsLookup.StatusList); } }

    public GameEntity AddStatusList(System.Collections.Generic.List<_Project.Code.Gameplay.Features.Status.Configs.StatusConfig> newValue) {
        var index = GameComponentsLookup.StatusList;
        var component = (_Project.Code.Gameplay.Features.Ability.AbilityComponents.StatusList)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Ability.AbilityComponents.StatusList));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceStatusList(System.Collections.Generic.List<_Project.Code.Gameplay.Features.Status.Configs.StatusConfig> newValue) {
        var index = GameComponentsLookup.StatusList;
        var component = (_Project.Code.Gameplay.Features.Ability.AbilityComponents.StatusList)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Ability.AbilityComponents.StatusList));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveStatusList() {
        RemoveComponent(GameComponentsLookup.StatusList);
        return this;
    }
}
