using _Project.Code.Common.Services.Time;
using _Project.Code.Gameplay.Input.Controls.Actions;
using Entitas;

namespace _Project.Code.Gameplay.Input.Controls.Systems
{
    public class ApplyControlsActionsSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _inputs;

        public ApplyControlsActionsSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _inputs = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.Controls
            ));
        }
        
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                foreach (var control in input.Controls)
                {
                    var activated = false;
                    foreach (var hotkey in control.HotKeys)
                    {
                        hotkey.Press.Update(_time.DeltaTime);
                        if (hotkey.IsActivated())
                        {
                            activated = true;
                        }
                    }
                    
                    if (activated)
                    {
                        control.Action.Assign(input);
                    }
                    else
                    {
                        control.Action.UnAssign(input);
                    }
                }
            }
        }
    }
}