using System.Collections.Generic;
using _Project.Code.Common.Services.StaticData;
using Entitas;

namespace _Project.Code.Gameplay.Features.Character.Systems
{
    public class UpdateCharacterSpeedIfIsSprintingChangesReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly IStaticDataService _staticData;

        public UpdateCharacterSpeedIfIsSprintingChangesReactiveSystem(GameContext game, IStaticDataService staticData) :
            base(game)
        {
            _staticData = staticData;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.AllOf(GameMatcher.Character, GameMatcher.Sprinting).AddedOrRemoved());

        protected override bool Filter(GameEntity character) => character.isCharacter;

        protected override void Execute(List<GameEntity> characters)
        {
            foreach (GameEntity character in characters)
            {
                character.ReplaceSpeed(character.isSprinting
                    ? _staticData.CharacterConfig.sprintSpeed
                    : _staticData.CharacterConfig.speed);
            }
        }
    }
}