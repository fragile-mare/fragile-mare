using _Project.Code.Gameplay.Features.Character.Systems;
using _Project.Code.Infrastructure.Systems;

namespace _Project.Code.Gameplay.Features.Character
{
    public class CharacterFeature : Feature
    {
        public CharacterFeature(ISystemsFactory systems)
        {
            Add(systems.Create<InitializeCharacterSystem>());

            Add(systems.Create<SetCharacterDirectionByInputSystem>());
            Add(systems.Create<SetCharacterSprintByInputSystem>());
            Add(systems.Create<SetCharacterDashByInputSystem>());

            Add(systems.Create<RotationCharacterSystem>());
        }
    }
}