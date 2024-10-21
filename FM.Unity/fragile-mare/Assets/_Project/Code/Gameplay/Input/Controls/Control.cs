using System.Collections.Generic;
using _Project.Code.Gameplay.Input.Controls.Actions;
using _Project.Code.Gameplay.Input.Controls.Keys;

namespace _Project.Code.Gameplay.Input.Controls
{
    public class Control
    {
        public GameAction Action;
        public List<HotKey> HotKeys;
    }
}