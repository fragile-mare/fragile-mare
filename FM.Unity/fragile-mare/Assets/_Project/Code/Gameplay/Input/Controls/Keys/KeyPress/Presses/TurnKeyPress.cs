namespace _Project.Code.Gameplay.Input.Controls.Keys.KeyPress.Presses
{
    /// <summary>
    /// Переключение нажатия.
    /// </summary>
    public class TurnKeyPress : IKeyPress
    {
        private HotKey _key;
        
        public object Clone() => MemberwiseClone();

        private bool _currentTurn;
        
        private bool _currentDown;
        private bool _currentHold;
        private bool _currentUp;

        public KeyPressType GetPressType()
        {
            return KeyPressType.Turn;
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
            if (_key.Is(UnityEngine.Input.GetKeyDown))
            {
                _currentTurn = !_currentTurn;

                if (_currentTurn) _currentDown = true;
                else _currentUp = true;
            }
            else
            {
                _currentUp = false;
                _currentDown = false;
            }

            _currentHold = _currentTurn;
        }
    }
}