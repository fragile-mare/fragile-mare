﻿using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _Project.Code.Gameplay.Features.Movement.Dash.Systems
{
    public class DashActivationSystem : IExecuteSystem
    {
        private readonly List<GameEntity> _buffer = new(64);

        private readonly IGroup<GameEntity> _dashers;

        public DashActivationSystem(GameContext game)
        {
            _dashers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.CanDash,
                GameMatcher.DashActivated,
                GameMatcher.DashDuration,
                GameMatcher.DashTimer
            ).NoneOf(
                GameMatcher.Dashing));
        }

        public void Execute()
        {
            foreach (GameEntity dasher in _dashers.GetEntities(_buffer))
            {
                if (dasher.hasDirection && dasher.Direction == Vector2.zero)
                {
                    continue;
                }

                if (dasher.hasDashCurrentCount)
                {
                    var curr = dasher.DashCurrentCount;
                    if (curr <= 0) continue;
                    dasher.ReplaceDashCurrentCount(curr - 1);
                }

                if (dasher.hasDirection)
                {
                    dasher.ReplaceDashDirection(dasher.Direction);
                }

                dasher.isDashing = true;
                dasher.ReplaceDashTimer(dasher.DashDuration);
            }
        }
    }
}