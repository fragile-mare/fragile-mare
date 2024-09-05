//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDashing;

    public static Entitas.IMatcher<GameEntity> Dashing {
        get {
            if (_matcherDashing == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Dashing);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDashing = matcher;
            }

            return _matcherDashing;
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

    static readonly _Project.Code.Gameplay.Features.Movement.Dash.Dashing dashingComponent = new _Project.Code.Gameplay.Features.Movement.Dash.Dashing();

    public bool isDashing {
        get { return HasComponent(GameComponentsLookup.Dashing); }
        set {
            if (value != isDashing) {
                var index = GameComponentsLookup.Dashing;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : dashingComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
