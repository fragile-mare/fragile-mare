//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCursorX;

    public static Entitas.IMatcher<GameEntity> CursorX {
        get {
            if (_matcherCursorX == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CursorX);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCursorX = matcher;
            }

            return _matcherCursorX;
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

    public _Project.Code.Gameplay.Input.CursorX cursorX { get { return (_Project.Code.Gameplay.Input.CursorX)GetComponent(GameComponentsLookup.CursorX); } }
    public float CursorX { get { return cursorX.Value; } }
    public bool hasCursorX { get { return HasComponent(GameComponentsLookup.CursorX); } }

    public GameEntity AddCursorX(float newValue) {
        var index = GameComponentsLookup.CursorX;
        var component = (_Project.Code.Gameplay.Input.CursorX)CreateComponent(index, typeof(_Project.Code.Gameplay.Input.CursorX));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCursorX(float newValue) {
        var index = GameComponentsLookup.CursorX;
        var component = (_Project.Code.Gameplay.Input.CursorX)CreateComponent(index, typeof(_Project.Code.Gameplay.Input.CursorX));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCursorX() {
        RemoveComponent(GameComponentsLookup.CursorX);
        return this;
    }
}
