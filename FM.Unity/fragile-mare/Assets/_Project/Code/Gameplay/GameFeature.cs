using _Project.Code.Common.Destruct;
using _Project.Code.Gameplay.Cameras;
using _Project.Code.Gameplay.Features.Character;
using _Project.Code.Gameplay.Features.Movement;
using _Project.Code.Gameplay.Input;
using _Project.Code.Infrastructure.Systems;
using _Project.Code.Infrastructure.View;

namespace _Project.Code.Gameplay
{
    public class GameFeature : Feature
    {
        public GameFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<CharacterFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<CameraFeature>());

            Add(systems.Create<EntityViewFeature>());
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}