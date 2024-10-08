//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEnergyToRegen;

    public static Entitas.IMatcher<GameEntity> EnergyToRegen {
        get {
            if (_matcherEnergyToRegen == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EnergyToRegen);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEnergyToRegen = matcher;
            }

            return _matcherEnergyToRegen;
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

    public _Project.Code.Gameplay.Features.Energy.EnergyToRegen energyToRegen { get { return (_Project.Code.Gameplay.Features.Energy.EnergyToRegen)GetComponent(GameComponentsLookup.EnergyToRegen); } }
    public float EnergyToRegen { get { return energyToRegen.Value; } }
    public bool hasEnergyToRegen { get { return HasComponent(GameComponentsLookup.EnergyToRegen); } }

    public GameEntity AddEnergyToRegen(float newValue) {
        var index = GameComponentsLookup.EnergyToRegen;
        var component = (_Project.Code.Gameplay.Features.Energy.EnergyToRegen)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Energy.EnergyToRegen));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceEnergyToRegen(float newValue) {
        var index = GameComponentsLookup.EnergyToRegen;
        var component = (_Project.Code.Gameplay.Features.Energy.EnergyToRegen)CreateComponent(index, typeof(_Project.Code.Gameplay.Features.Energy.EnergyToRegen));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveEnergyToRegen() {
        RemoveComponent(GameComponentsLookup.EnergyToRegen);
        return this;
    }
}
