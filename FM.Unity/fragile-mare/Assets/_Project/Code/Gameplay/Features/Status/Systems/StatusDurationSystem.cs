using System.Collections.Generic;
using _Project.Code.Common.Services.Time;
using Entitas;

namespace _Project.Code.Gameplay.Features.Status.Systems
{
    public class StatusDurationSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(32);
        private readonly IGroup<GameEntity> _statuses;
        private readonly ITimeService _time;

        public StatusDurationSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.DurationTimer)
                .NoneOf(GameMatcher.Expired));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses.GetEntities(_buffer))
            {
                status.ReplaceDurationTimer(status.DurationTimer - _time.DeltaTime);

                if (status.DurationTimer <= 0)
                {
                    status.isExpired = true;
                }
            }
        }
    }
}