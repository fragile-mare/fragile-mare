//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRigidbody;

    public static Entitas.IMatcher<GameEntity> Rigidbody {
        get {
            if (_matcherRigidbody == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Rigidbody);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRigidbody = matcher;
            }

            return _matcherRigidbody;
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

    public _Project.Code.Gameplay.Features.Physic.RigidbodyComponent rigidbody { get { return (_Project.Code.Gameplay.Features.Physic.RigidbodyComponent)GetComponent(GameComponentsLookup.Rigidbody); } }
    public UnityEngine.Rigidbody Rigidbody { get { return rigidbody.Value; } }
    public bool hasRigidbody { get { return HasComponent(GameComponentsLookup.Rigidbody); } }

    public GameEntity AddRigidbody(UnityEngine.Rigidbody newValue) {
        var index = GameComponentsLookup.Rigidbody;
        var component = (_Project.Code.Gameplay.Features.Physic.RigidbodyComponent)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Physic.RigidbodyComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceRigidbody(UnityEngine.Rigidbody newValue) {
        var index = GameComponentsLookup.Rigidbody;
        var component = (_Project.Code.Gameplay.Features.Physic.RigidbodyComponent)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Physic.RigidbodyComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveRigidbody() {
        RemoveComponent(GameComponentsLookup.Rigidbody);
        return this;
    }
}
