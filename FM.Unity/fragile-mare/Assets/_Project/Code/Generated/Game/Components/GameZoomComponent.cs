//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherZoom;

    public static Entitas.IMatcher<GameEntity> Zoom {
        get {
            if (_matcherZoom == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Zoom);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherZoom = matcher;
            }

            return _matcherZoom;
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

    public _Project.Code.Gameplay.Input.Zoom zoom { get { return (_Project.Code.Gameplay.Input.Zoom)GetComponent(GameComponentsLookup.Zoom); } }
    public float Zoom { get { return zoom.Value; } }
    public bool hasZoom { get { return HasComponent(GameComponentsLookup.Zoom); } }

    public GameEntity AddZoom(float newValue) {
        var index = GameComponentsLookup.Zoom;
        var component = (_Project.Code.Gameplay.Input.Zoom)CreateComponent(index, typeof(_Project.Code.Gameplay.Input.Zoom));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceZoom(float newValue) {
        var index = GameComponentsLookup.Zoom;
        var component = (_Project.Code.Gameplay.Input.Zoom)CreateComponent(index, typeof(_Project.Code.Gameplay.Input.Zoom));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveZoom() {
        RemoveComponent(GameComponentsLookup.Zoom);
        return this;
    }
}
