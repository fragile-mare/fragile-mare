using System.Collections.Generic;
using _Project.Code.Gameplay.Input.Controls.Actions;

namespace _Project.Code.Gameplay.Input.Controls.Services
{
    public interface IDefaultControlsProvider
    {
        Control GetDefaultControl(GameAction action);
        List<Control> GetDefaultControlsCopy();
    }
}