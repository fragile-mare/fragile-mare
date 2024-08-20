﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace src.Utils.HotKey
{
    [Serializable]
    public class HotKey
    {
        /// Сюда входят модификаторы, такие как [shift], [ctrl], [alt].
        public List<ModifierKey> modifiers = new();
        
        /// Здесь назначается главная кнопка.
        public KeyCode key;
        
        /// Проверяет, нажато ли сочетание клавиш. Должна быть нажата главная кнопка, то есть *key*, и
        /// все модификаторы, то есть *modifiers*.
        public bool IsPressed()
        {
            if (key == KeyCode.None) return false;
            return Input.GetKey(key) && modifiers.All(Modifier.IsModifierPressed);
        }

        /// Чем конкретнее сочетание клавиш, тем больше приоритет (например, [ctrl+shift+w] > [shift+w] > [w]).
        /// То есть, если есть сочетание [w] - ходьба, и [shift+w] - бег, при нажатии [shift+w] активируется 
        /// только действие на [shift+w], то есть на бег (обычное [w] проигнорируется).
        public int GetPriority()
        {
            if (key == KeyCode.None) return 0;
            return modifiers.Count + 1;
        }
    }

    public enum ModifierKey
    {
        Shift,
        Ctrl,
        Alt,
    }

    public static class Modifier
    {
        public static bool IsModifierPressed(ModifierKey modifierKey)
        {
            return IsModifier(modifierKey, Input.GetKey);
        }

        /// <summary>
        ///  Проверяем, нажата ли одна из кнопок модификатора - правая или левая.
        /// </summary>
        /// <param name="modifierKey">Сам модификатор.</param>
        /// <param name="checker">
        ///     Функция, с помощью которой проверяем нажат ли модификатор.
        ///     Может быть: [Input.GetKey, Input.GetKeyDown, Input.GetKeyUp]
        ///     или своя функция с такой сигнатурой.
        /// </param>
        public static bool IsModifier(ModifierKey modifierKey, Func<KeyCode, bool> checker)
        {
            return modifierKey switch
            {
                ModifierKey.Shift => checker(KeyCode.LeftShift) || checker(KeyCode.RightShift),
                ModifierKey.Ctrl => checker(KeyCode.LeftControl) || checker(KeyCode.RightControl),
                ModifierKey.Alt => checker(KeyCode.LeftAlt) || checker(KeyCode.RightAlt),
                _ => false
            };
        }
    }
}