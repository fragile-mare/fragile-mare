using System;
using src.pubsub;
using src.Topics.General;
using src.Topics.Player;
using src.Topics.Player.InputActions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = src.Utils.Debug.Debug;

namespace src.Scripts.Player
{
    public class PlayerCharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1f;
        
        [SerializeField] private Transform playerTransform;

        [SerializeField] private Camera playerCamera;
        
        private Vector3 _moveInThisFrame = Vector3.zero;

        private Subscription _playerActionsSub;
        
        void Start()
        {
            if (playerCamera == null) playerCamera = Camera.main;
            
            InputActionsTopic.Subscribe(@params =>
            {
                var move = GetMoveVector(@params.InputAction);
                if (move == Vector3.zero)
                {
                    Debug.LogError($"Unknown player action type. type: \"{@params.InputAction}\"");
                }

                _moveInThisFrame += move;
            }, out _playerActionsSub);
        }
        
        private void OnEnable()
        {
            Topics.Player.PlayerCharacterMovement.Publish(new MovementParams 
            {
                Move = Vector3.zero,
                OldPosition = playerTransform.position
            });
        }

        private void Update()
        {
            var pos = playerTransform.position;
                
            Topics.Player.PlayerCharacterMovement.Publish(new MovementParams 
            {
                Move = _moveInThisFrame,
                OldPosition = pos
            });

            pos += _moveInThisFrame;
            playerTransform.position = pos;
            
            _moveInThisFrame = Vector3.zero;
        }

        private void OnDestroy()
        {
            _playerActionsSub.Unsubscribe();
        }

        public Vector3 GetMoveVector(InputAction action)
        {
            return action switch
            {
                InputAction.MoveForward => Vector3.forward * speed,
                InputAction.MoveBack => Vector3.back * speed,
                InputAction.MoveRight => Vector3.right * speed,
                InputAction.MoveLeft => Vector3.left * speed,
                _ => Vector3.zero
            };
        }

        private static float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
    }
}
