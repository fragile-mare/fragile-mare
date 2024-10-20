//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherExpired;

    public static Entitas.IMatcher<GameEntity> Expired {
        get {
            if (_matcherExpired == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Expired);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherExpired = matcher;
            }

            return _matcherExpired;
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

    static readonly _Project.Code.Gameplay.Features.Status.Expired expiredComponent = new _Project.Code.Gameplay.Features.Status.Expired();

    public bool isExpired {
        get { return HasComponent(GameComponentsLookup.Expired); }
        set {
            if (value != isExpired) {
                var index = GameComponentsLookup.Expired;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : expiredComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
