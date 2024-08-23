using System;
using src.pubsub;
using src.Topics.Player;
using src.Topics.Player.InputActions;
using UnityEngine;

namespace src.Scripts.Player
{
    public class PlayerActionsMux : MonoBehaviour
    {
        private Subscription _playerActionsSub;
        public void Start()
        {
            // todo: группировать разные действия игрока по топикам.
            // todo: передвижение - в один, бой - в другой и т.д.
            InputActionsTopic.Subscribe(@params =>
            {
            }, out _playerActionsSub);
        }

        private void OnDestroy()
        {
            _playerActionsSub.Unsubscribe();
        }
    }
}