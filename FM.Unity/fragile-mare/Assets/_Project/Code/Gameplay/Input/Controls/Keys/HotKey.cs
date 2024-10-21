using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Code.Gameplay.Input.Controls.Keys.KeyPress.Presses;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Controls.Keys
{
    public class HotKey : ICloneable
    {
        public KeyCode MainKey;
        public List<Modifier> Modifiers;
        
        public IKeyPress Press;
        public HotKeyType HotKeyType;

        public HotKey(KeyCode mainKey, List<Modifier> modifiers, IKeyPress press, HotKeyType type)
        {
            MainKey = mainKey;
            Modifiers = modifiers;
            Press = press;
            Press.SetHotKey(this);
            HotKeyType = type;
        }

        public bool IsActivated()
        {
            return HotKeyType switch
            {
                HotKeyType.Down => IsDown(),
                HotKeyType.Hold => IsHold(),
                HotKeyType.Up => IsUp(),
                _ => false
            };
        }

        private bool IsDown() => Press.IsDown();
        private bool IsUp() => Press.IsUp();
        private bool IsHold() => Press.IsHold();

        public bool Is(Func<KeyCode, bool> checker)
        {
            return checker(MainKey) && Modifiers.All(modifier => modifier.IsModifier(checker));
        }

        public object Clone()
        {
            return new HotKey(MainKey, Modifiers, Press.Clone() as IKeyPress, HotKeyType);
        }
    }
    
    public enum HotKeyType
    {
        Down, Hold, Up
    }
}