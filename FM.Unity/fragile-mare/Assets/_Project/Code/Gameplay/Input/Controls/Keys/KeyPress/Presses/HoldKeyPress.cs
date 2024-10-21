using System;

namespace _Project.Code.Gameplay.Input.Controls.Keys.KeyPress.Presses
{
    /// <summary>
    /// Зажатие клавиши в течение holdDuration секунд.
    /// </summary>
    [Serializable]
    public class HoldKeyPress : IKeyPress
    {
        public float holdDuration;
        
        private HotKey _key;
        
        private float _currentDuration;
        
        private bool _currentDown;
        private bool _currentHold;
        private bool _currentUp;
        
        public KeyPressType GetPressType()
        {
            return KeyPressType.Hold;
        }

        public void SetHotKey(HotKey key)
        {
            _key = key;
        }

        public bool IsDown() => _currentDown;
        public bool IsUp() => _currentUp;
        public bool IsHold() => _currentHold;

        public void Update(float time)
        {
            if (_key.Is(UnityEngine.Input.GetKey))
            {
                _currentDuration += time;
                if (_currentDuration < holdDuration) return;
                
                _currentDown = _currentHold == false;
                _currentHold = true;
            }
            else
            {
                _currentUp = _currentHold;

                _currentHold = false;
                _currentDuration = 0;
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}