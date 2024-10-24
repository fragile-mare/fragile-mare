//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherControls;

    public static Entitas.IMatcher<GameEntity> Controls {
        get {
            if (_matcherControls == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Controls);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherControls = matcher;
            }

            return _matcherControls;
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

    public _Project.Code.Gameplay.Input.ControlsComponent controls { get { return (_Project.Code.Gameplay.Input.ControlsComponent)GetComponent(GameComponentsLookup.Controls); } }
    public System.Collections.Generic.List<_Project.Code.Gameplay.Input.Controls.Control> Controls { get { return controls.Value; } }
    public bool hasControls { get { return HasComponent(GameComponentsLookup.Controls); } }

    public GameEntity AddControls(System.Collections.Generic.List<_Project.Code.Gameplay.Input.Controls.Control> newValue) {
        var index = GameComponentsLookup.Controls;
        var component = (_Project.Code.Gameplay.Input.ControlsComponent)CreateComponent(index, typeof(_Project.Code.Gameplay.Input.ControlsComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceControls(System.Collections.Generic.List<_Project.Code.Gameplay.Input.Controls.Control> newValue) {
        var index = GameComponentsLookup.Controls;
        var component = (_Project.Code.Gameplay.Input.ControlsComponent)CreateComponent(index, typeof(_Project.Code.Gameplay.Input.ControlsComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveControls() {
        RemoveComponent(GameComponentsLookup.Controls);
        return this;
    }
}
