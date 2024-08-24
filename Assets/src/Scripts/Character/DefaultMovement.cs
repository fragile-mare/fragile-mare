using src.pubsub;
using src.Topics.General;
using src.Topics.Player.InputActions;
using UnityEngine;
using Debug = src.Utils.WDebug.Debug;

namespace src.Scripts.Character
{
    public class DefaultMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1f;
        
        private Transform _targetTransform;
        
        private Vector3 _moveInThisFrame = Vector3.zero;

        private Subscription _playerActionsSub;

        private string _topicPrefix;

        private Topic<MovementParams> _movementTopic;
        
        void Start()
        {
            var entity = GetComponentInParent<Entity>();
            if (entity == null)
            {
                Debug.LogError("Need to add Entity class into parent");
                return;
            }
            
            _topicPrefix = entity.topicPrefix;
            _targetTransform = entity.targetTransform;

            _movementTopic = MovementTopic.CreateTopic(_topicPrefix);
            _movementTopic.Publish(new MovementParams 
            {
                Move = Vector3.zero,
                OldPosition = _targetTransform.position
            });

            var movementActionsTopic = MovementActionsTopic.GetTopic(_topicPrefix);
            movementActionsTopic.Subscribe(@params =>
            {
                var move = GetMoveVector(@params);
                if (move == Vector3.zero)
                {
                    Debug.LogError($"Unknown movement action type. type: \"{@params}\"");
                }
                
                // todo: neg move and pos move, detect max, in update: pos + neg.
                _moveInThisFrame += move;
                Debug.Log(_moveInThisFrame.ToString());
            }, out _playerActionsSub);
        }
        
        private void Update()
        {
            var pos = _targetTransform.position;

            _movementTopic.Publish(new MovementParams 
            {
                Move = _moveInThisFrame,
                OldPosition = pos
            });

            pos += _moveInThisFrame;
            _targetTransform.position = pos;
            
            _moveInThisFrame = Vector3.zero;
        }

        private void OnDestroy()
        {
            _playerActionsSub.Unsubscribe();
        }

        public Vector3 GetMoveVector(MovementAction action)
        {
            return action switch
            {
                MovementAction.MoveForward => Vector3.forward * speed,
                MovementAction.MoveBack => Vector3.back * speed,
                MovementAction.MoveRight => Vector3.right * speed,
                MovementAction.MoveLeft => Vector3.left * speed,
                _ => Vector3.zero
            };
        }

        private static float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
    }
}
