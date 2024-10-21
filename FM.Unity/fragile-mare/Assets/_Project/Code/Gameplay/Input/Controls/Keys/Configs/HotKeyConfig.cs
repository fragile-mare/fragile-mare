using System;
using System.Collections.Generic;
using _Project.Code.Gameplay.Input.Controls.Keys.KeyPress.Config;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Controls.Keys.Configs
{
    [Serializable]
    public class HotKeyConfig
    {
        public KeyCode mainKey;
        public List<Modifier> modifiers;
        public HotKeyType type;
        public KeyPressConfig keyPress;
    }
}