//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSphereRelativePushAbility;

    public static Entitas.IMatcher<GameEntity> SphereRelativePushAbility {
        get {
            if (_matcherSphereRelativePushAbility == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.SphereRelativePushAbility);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSphereRelativePushAbility = matcher;
            }

            return _matcherSphereRelativePushAbility;
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

    static readonly _Project.Code.Gameplay.Features.Physics.RelativePush.RelativePushComponents.SphereRelativePushAbility sphereRelativePushAbilityComponent = new _Project.Code.Gameplay.Features.Physics.RelativePush.RelativePushComponents.SphereRelativePushAbility();

    public bool isSphereRelativePushAbility {
        get { return HasComponent(GameComponentsLookup.SphereRelativePushAbility); }
        set {
            if (value != isSphereRelativePushAbility) {
                var index = GameComponentsLookup.SphereRelativePushAbility;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : sphereRelativePushAbilityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}