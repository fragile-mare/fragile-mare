using System;
using System.Collections.Generic;
using _Project.Code.Gameplay.Input.Controls.Actions;
using _Project.Code.Gameplay.Input.Controls.Keys.Configs;
using UnityEngine.Serialization;

namespace _Project.Code.Gameplay.Input.Controls
{
    [Serializable]
    public class ControlConfig
    {
        public GameAction action;
        public List<HotKeyConfig> hotKeys;
    }
}