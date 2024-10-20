//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEffectList;

    public static Entitas.IMatcher<GameEntity> EffectList {
        get {
            if (_matcherEffectList == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EffectList);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEffectList = matcher;
            }

            return _matcherEffectList;
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

    public _Project.Code.Gameplay.Features.Ability.AbilityComponents.EffectList effectList { get { return (_Project.Code.Gameplay.Features.Ability.AbilityComponents.EffectList)GetComponent(GameComponentsLookup.EffectList); } }
    public System.Collections.Generic.List<_Project.Code.Gameplay.Features.Effect.Configs.EffectConfig> EffectList { get { return effectList.Value; } }
    public bool hasEffectList { get { return HasComponent(GameComponentsLookup.EffectList); } }

    public GameEntity AddEffectList(System.Collections.Generic.List<_Project.Code.Gameplay.Features.Effect.Configs.EffectConfig> newValue) {
        var index = GameComponentsLookup.EffectList;
        var component = (_Project.Code.Gameplay.Features.Ability.AbilityComponents.EffectList)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Ability.AbilityComponents.EffectList));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceEffectList(System.Collections.Generic.List<_Project.Code.Gameplay.Features.Effect.Configs.EffectConfig> newValue) {
        var index = GameComponentsLookup.EffectList;
        var component = (_Project.Code.Gameplay.Features.Ability.AbilityComponents.EffectList)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Ability.AbilityComponents.EffectList));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveEffectList() {
        RemoveComponent(GameComponentsLookup.EffectList);
        return this;
    }
}
