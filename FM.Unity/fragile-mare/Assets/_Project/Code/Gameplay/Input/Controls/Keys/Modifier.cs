using System;
using UnityEngine;

namespace _Project.Code.Gameplay.Input.Controls.Keys
{
    public enum Modifier
    {
        Shift, Ctrl, Alt
    }

    public static class ModifierExtensions
    {
        public static bool IsModifier(this Modifier modifier, Func<KeyCode, bool> checker)
        {
            return modifier switch
            {
                Modifier.Shift => checker(KeyCode.LeftShift) || checker(KeyCode.RightShift),
                Modifier.Ctrl => checker(KeyCode.LeftControl) || checker(KeyCode.RightControl),
                Modifier.Alt => checker(KeyCode.LeftAlt) || checker(KeyCode.RightAlt),
                _ => false
            };
        }
    }
}