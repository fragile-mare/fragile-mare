//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherImpulseEffect;

    public static Entitas.IMatcher<GameEntity> ImpulseEffect {
        get {
            if (_matcherImpulseEffect == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ImpulseEffect);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherImpulseEffect = matcher;
            }

            return _matcherImpulseEffect;
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

    static readonly _Project.Code.Gameplay.Features.Physics.Impulse.ImpulseComponents.ImpulseEffect impulseEffectComponent = new _Project.Code.Gameplay.Features.Physics.Impulse.ImpulseComponents.ImpulseEffect();

    public bool isImpulseEffect {
        get { return HasComponent(GameComponentsLookup.ImpulseEffect); }
        set {
            if (value != isImpulseEffect) {
                var index = GameComponentsLookup.ImpulseEffect;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : impulseEffectComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
