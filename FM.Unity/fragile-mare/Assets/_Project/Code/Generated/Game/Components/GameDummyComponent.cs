//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDummy;

    public static Entitas.IMatcher<GameEntity> Dummy {
        get {
            if (_matcherDummy == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Dummy);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDummy = matcher;
            }

            return _matcherDummy;
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

    static readonly _Project.Code.Gameplay.Features.Dummy.Dummy dummyComponent = new _Project.Code.Gameplay.Features.Dummy.Dummy();

    public bool isDummy {
        get { return HasComponent(GameComponentsLookup.Dummy); }
        set {
            if (value != isDummy) {
                var index = GameComponentsLookup.Dummy;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : dummyComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
