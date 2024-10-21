using System;

namespace _Project.Code.Gameplay.Input.Controls.Keys.KeyPress.Presses
{
    /// <summary>
    /// Обычное нажатие клавиши.
    /// </summary>
    [Serializable]
    public class InstantKeyPress : IKeyPress
    {
        private HotKey _key;
        
        public KeyPressType GetPressType()
        {
            return KeyPressType.Single;
        }
        
        public void SetHotKey(HotKey key)
        {
            _key = key;
        }

        public bool IsDown()
        {
            return _key.Is(UnityEngine.Input.GetKeyDown);
        }

        public bool IsUp()
        {
            return _key.Is(UnityEngine.Input.GetKeyUp);
        }

        public bool IsHold()
        {
            return _key.Is(UnityEngine.Input.GetKey);
        }

        public void Update(float time) { }
        
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}