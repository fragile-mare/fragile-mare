using System;
using System.Linq;

namespace _Project.Code.Gameplay.Input.Controls.Keys.KeyPress.Presses
{
    /// <summary>
    /// Быстрое нажатие клавиши с интервалом pressInterval в количестве pressCount раз.
    /// </summary>
    [Serializable]
    public class IntervalKeyPress : IKeyPress
    {
        public int pressCount;
        public float pressInterval;

        private int _currentCount;
        private float _currentInterval;
        
        private bool _currentDown;
        private bool _currentHold;
        private bool _currentUp;
        
        private HotKey _key;
        
        public KeyPressType GetPressType()
        {
            return KeyPressType.Multiple;
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
            var keyDown = UnityEngine.Input.GetKeyDown(_key.MainKey) 
                          && _key.Modifiers.All(modifier => modifier.IsModifier(UnityEngine.Input.GetKey));
            var keyHold = _key.Is(UnityEngine.Input.GetKey);
            
            if (keyDown)
            {
                _currentCount++;
                _currentInterval = 0;
            }
            
            if ((keyDown || keyHold) && _currentCount >= pressCount)
            {
                _currentDown = _currentHold == false;
                _currentHold = true;
            }

            if (_currentHold && !keyHold)
            {
                _currentUp = true;
                _currentHold = false;
                _currentCount = 0;
                _currentInterval = 0;
                return;
            }

            _currentUp = false;
            _currentInterval += time;
            
            if (_currentInterval <= pressInterval) return;
            
            _currentCount = 0;
            _currentInterval = 0;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}