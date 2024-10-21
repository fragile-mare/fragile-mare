using System;

namespace _Project.Code.Gameplay.Input.Controls.Keys.KeyPress.Presses
{
    public interface IKeyPress : ICloneable
    {
        KeyPressType GetPressType();
        void SetHotKey(HotKey key);
        bool IsDown();
        bool IsUp();
        bool IsHold();
        void Update(float time);
    }
}