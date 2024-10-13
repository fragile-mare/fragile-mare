//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Destructed = 0;
    public const int Id = 1;
    public const int SelfDestructTimer = 2;
    public const int Transform = 3;
    public const int View = 4;
    public const int ViewPath = 5;
    public const int ViewPrefab = 6;
    public const int WorldPosition = 7;
    public const int WorldRotation = 8;
    public const int Character = 9;
    public const int CurrentEnergy = 10;
    public const int EnergyRegenTimer = 11;
    public const int EnergyToApply = 12;
    public const int EnergyToRegen = 13;
    public const int EnergyType = 14;
    public const int MaxEnergy = 15;
    public const int CanDash = 16;
    public const int DashActivated = 17;
    public const int DashCurrentCount = 18;
    public const int DashDirection = 19;
    public const int DashDuration = 20;
    public const int Dashing = 21;
    public const int DashMaxCount = 22;
    public const int DashRegenAmount = 23;
    public const int DashRegenAmountToApply = 24;
    public const int DashRegenDuration = 25;
    public const int DashRegenTimer = 26;
    public const int DashSpeed = 27;
    public const int DashTimer = 28;
    public const int Direction = 29;
    public const int CanMove = 30;
    public const int Moving = 31;
    public const int Speed = 32;
    public const int CanSprint = 33;
    public const int Sprinting = 34;
    public const int SprintSpeed = 35;
    public const int CameraOffsetInitialized = 36;
    public const int CursorX = 37;
    public const int CursorY = 38;
    public const int DashButtonPressed = 39;
    public const int Input = 40;
    public const int InputCursorAxis = 41;
    public const int InputMovementAxis = 42;
    public const int LimitRotationY = 43;
    public const int MouseScrollWheel = 44;
    public const int MouseSens = 45;
    public const int Offset = 46;
    public const int SprintButtonPressed = 47;
    public const int XRotationCursor = 48;
    public const int YRotationCursor = 49;
    public const int Zoom = 50;
    public const int ZoomMax = 51;
    public const int ZoomMin = 52;

    public const int TotalComponents = 53;

    public static readonly string[] componentNames = {
        "Destructed",
        "Id",
        "SelfDestructTimer",
        "Transform",
        "View",
        "ViewPath",
        "ViewPrefab",
        "WorldPosition",
        "WorldRotation",
        "Character",
        "CurrentEnergy",
        "EnergyRegenTimer",
        "EnergyToApply",
        "EnergyToRegen",
        "EnergyType",
        "MaxEnergy",
        "CanDash",
        "DashActivated",
        "DashCurrentCount",
        "DashDirection",
        "DashDuration",
        "Dashing",
        "DashMaxCount",
        "DashRegenAmount",
        "DashRegenAmountToApply",
        "DashRegenDuration",
        "DashRegenTimer",
        "DashSpeed",
        "DashTimer",
        "Direction",
        "CanMove",
        "Moving",
        "Speed",
        "CanSprint",
        "Sprinting",
        "SprintSpeed",
        "CameraOffsetInitialized",
        "CursorX",
        "CursorY",
        "DashButtonPressed",
        "Input",
        "InputCursorAxis",
        "InputMovementAxis",
        "LimitRotationY",
        "MouseScrollWheel",
        "MouseSens",
        "Offset",
        "SprintButtonPressed",
        "XRotationCursor",
        "YRotationCursor",
        "Zoom",
        "ZoomMax",
        "ZoomMin"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(_Project.Code.Gameplay.Common.Destructed),
        typeof(_Project.Code.Gameplay.Common.Id),
        typeof(_Project.Code.Gameplay.Common.SelfDestructTimer),
        typeof(_Project.Code.Gameplay.Common.TransformComponent),
        typeof(_Project.Code.Gameplay.Common.View),
        typeof(_Project.Code.Gameplay.Common.ViewPath),
        typeof(_Project.Code.Gameplay.Common.ViewPrefab),
        typeof(_Project.Code.Gameplay.Common.WorldPosition),
        typeof(_Project.Code.Gameplay.Common.WorldRotation),
        typeof(_Project.Code.Gameplay.Features.Character.Character),
        typeof(_Project.Code.Gameplay.Features.Energy.CurrentEnergy),
        typeof(_Project.Code.Gameplay.Features.Energy.EnergyRegenTimer),
        typeof(_Project.Code.Gameplay.Features.Energy.EnergyToApply),
        typeof(_Project.Code.Gameplay.Features.Energy.EnergyToRegen),
        typeof(_Project.Code.Gameplay.Features.Energy.EnergyType),
        typeof(_Project.Code.Gameplay.Features.Energy.MaxEnergy),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.CanDash),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashActivated),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashCurrentCount),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashDirection),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashDuration),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.Dashing),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashMaxCount),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashRegenAmount),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashRegenAmountToApply),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashRegenDuration),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashRegenTimer),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashSpeed),
        typeof(_Project.Code.Gameplay.Features.Movement.Dash.DashTimer),
        typeof(_Project.Code.Gameplay.Features.Movement.Direction),
        typeof(_Project.Code.Gameplay.Features.Movement.Move.CanMove),
        typeof(_Project.Code.Gameplay.Features.Movement.Move.Moving),
        typeof(_Project.Code.Gameplay.Features.Movement.Move.Speed),
        typeof(_Project.Code.Gameplay.Features.Movement.Sprint.CanSprint),
        typeof(_Project.Code.Gameplay.Features.Movement.Sprint.Sprinting),
        typeof(_Project.Code.Gameplay.Features.Movement.Sprint.SprintSpeed),
        typeof(_Project.Code.Gameplay.Input.CameraOffsetInitialized),
        typeof(_Project.Code.Gameplay.Input.CursorX),
        typeof(_Project.Code.Gameplay.Input.CursorY),
        typeof(_Project.Code.Gameplay.Input.DashButtonPressed),
        typeof(_Project.Code.Gameplay.Input.Input),
        typeof(_Project.Code.Gameplay.Input.InputCursorAxis),
        typeof(_Project.Code.Gameplay.Input.InputMovementAxis),
        typeof(_Project.Code.Gameplay.Input.LimitRotationY),
        typeof(_Project.Code.Gameplay.Input.MouseScrollWheel),
        typeof(_Project.Code.Gameplay.Input.MouseSens),
        typeof(_Project.Code.Gameplay.Input.Offset),
        typeof(_Project.Code.Gameplay.Input.SprintButtonPressed),
        typeof(_Project.Code.Gameplay.Input.XRotationCursor),
        typeof(_Project.Code.Gameplay.Input.YRotationCursor),
        typeof(_Project.Code.Gameplay.Input.Zoom),
        typeof(_Project.Code.Gameplay.Input.ZoomMax),
        typeof(_Project.Code.Gameplay.Input.ZoomMin)
    };
}
