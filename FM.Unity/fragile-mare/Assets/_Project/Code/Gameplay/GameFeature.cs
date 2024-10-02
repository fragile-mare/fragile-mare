using _Project.Code.Common.Destruct;
using _Project.Code.Gameplay.Cameras;
using _Project.Code.Gameplay.Features.Ability;
using _Project.Code.Gameplay.Features.Camera;
using _Project.Code.Gameplay.Features.Character;
using _Project.Code.Gameplay.Features.Dummy;
using _Project.Code.Gameplay.Features.Effect;
using _Project.Code.Gameplay.Features.Energy;
using _Project.Code.Gameplay.Features.Movement;
using _Project.Code.Gameplay.Features.Status;
using _Project.Code.Gameplay.Input;
using _Project.Code.Infrastructure.Systems;
using _Project.Code.Infrastructure.View;

namespace _Project.Code.Gameplay
{
    public sealed class GameFeature : Feature
    {
        public GameFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<CharacterFeature>());
            Add(systems.Create<DummyFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<CamerasFeature>());
            Add(systems.Create<CameraFeature>());
            Add(systems.Create<AbilityFeature>());
            Add(systems.Create<StatusFeature>());
            Add(systems.Create<EffectFeature>());

            Add(systems.Create<EntityViewFeature>());
            Add(systems.Create<EnergyFeature>());
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}