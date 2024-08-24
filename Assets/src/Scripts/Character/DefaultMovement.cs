using System;
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
        
        [SerializeField]
        private float sprintSpeed = 1f;
        
        private Transform _targetTransform;

        private MoveState _forwardState = MoveState.None;
        private MoveState _backState = MoveState.None;
        private MoveState _rightState = MoveState.None;
        private MoveState _leftState = MoveState.None;

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
            movementActionsTopic.Subscribe(movementAction =>
            {
                SetMoveState(movementAction);
            }, out _playerActionsSub);
        }
        
        private void Update()
        {
            var pos = _targetTransform.position;

            var move = Vector3.zero;

            move += GetMoveVector(_forwardState, Vector3.forward);
            move += GetMoveVector(_backState, Vector3.back);
            move += GetMoveVector(_rightState, Vector3.right);
            move += GetMoveVector(_leftState, Vector3.left);

            pos += move;
            _targetTransform.position = pos;
            
            _movementTopic.Publish(new MovementParams 
            {
                Move = move,
                OldPosition = pos
            });
            
            Debug.Log(move.ToString());
            
            _forwardState = MoveState.None;
            _backState = MoveState.None;
            _rightState = MoveState.None;
            _leftState = MoveState.None;
        }

        private void OnDestroy()
        {
            _playerActionsSub.Unsubscribe();
        }

        public Vector3 GetMoveVector(MoveState state, Vector3 direction)
        {
            return state switch
            {
                MoveState.None => Vector3.zero,
                MoveState.Move => speed * direction,
                MoveState.Sprint => sprintSpeed * direction,
                _ => Vector3.zero
            };
        }
        
        public void SetMoveState(MovementAction action)
        {
            switch (action)
            {
                case MovementAction.MoveForward:
                    _forwardState = MoveState.Move;
                    break;
                case MovementAction.MoveBack:
                    _backState = MoveState.Move;
                    break;
                case MovementAction.MoveRight:
                    _rightState = MoveState.Move;
                    break;
                case MovementAction.MoveLeft:
                    _leftState = MoveState.Move;
                    break;
                
                case MovementAction.SprintForward:
                    _forwardState = MoveState.Sprint;
                    break;
                case MovementAction.SprintBack:
                    _backState = MoveState.Sprint;
                    break;
                case MovementAction.SprintRight:
                    _rightState = MoveState.Sprint;
                    break;
                case MovementAction.SprintLeft:
                    _leftState = MoveState.Sprint;
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }
    }

    public enum MoveState
    {
        None,
        Move,
        Sprint,
    }
}
