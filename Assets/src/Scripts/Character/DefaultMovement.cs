using System;
using System.Collections;
using System.Numerics;
using src.pubsub;
using src.Topics.General;
using src.Topics.Player.InputActions;
using UnityEngine;
using Debug = src.Utils.WDebug.Debug;
using Vector3 = UnityEngine.Vector3;

namespace src.Scripts.Character
{
    public class DefaultMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1f;
        
        [SerializeField]
        private float sprintSpeed = 1f;

        [SerializeField] [Min(0f)] 
        private float dashDuration;

        [SerializeField] [Min(0f)] 
        private float dashSpeed;

        [SerializeField] 
        private int maxDashCount;

        [SerializeField] [Min(0f)] 
        private float oneDashRegenDuration;
        
        private Transform _targetTransform;

        private MovementState _movementState = MovementState.Default;

        private MoveState _forwardState = MoveState.None;
        private MoveState _backState = MoveState.None;
        private MoveState _rightState = MoveState.None;
        private MoveState _leftState = MoveState.None;

        private DashState _dashState = DashState.None;
        private int _currentDashCount = 0;
        private float _remainingDashDuration = 0;
        private bool _isDashRegenerationActive = false;

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

            _currentDashCount = maxDashCount;

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
            var move = Vector3.zero;
            move += GetMoveVector(_forwardState, Vector3.forward);
            move += GetMoveVector(_backState, Vector3.back);
            move += GetMoveVector(_rightState, Vector3.right);
            move += GetMoveVector(_leftState, Vector3.left);

            if (_dashState == DashState.Active 
                && _currentDashCount > 0
                && _movementState == MovementState.Default)
            {
                _movementState = MovementState.Dash;
                _remainingDashDuration = dashDuration;
            }

            if (!_isDashRegenerationActive)
            {
                StartCoroutine(DashRegeneration());
            }
            
            switch (_movementState)
            {
                case MovementState.Default:
                    move = DefaultMove(move);
                    break;
                case MovementState.Dash:
                    move = DashMove(move);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            var pos = _targetTransform.position;
            pos += move;
            _targetTransform.position = pos;
            
            _movementTopic.Publish(new MovementParams 
            {
                Move = move,
                OldPosition = pos
            });
            
            _forwardState = MoveState.None;
            _backState = MoveState.None;
            _rightState = MoveState.None;
            _leftState = MoveState.None;
            _dashState = DashState.None;
        }

        private void OnDestroy()
        {
            _playerActionsSub.Unsubscribe();
        }

        private Vector3 DefaultMove(Vector3 move)
        {
            Debug.Log(move.ToString());

            return move;
        }

        private Vector3 DashMove(Vector3 move)
        {
            move = move.normalized; // сделать то же самое со sprint и убрать этот normalized

            _remainingDashDuration -= Time.deltaTime;
            if (_remainingDashDuration > 0)
            {
                move *= dashSpeed;
                return move;
            }
            
            if (_remainingDashDuration < 0 && Time.deltaTime > 0)
            {
                move *= dashSpeed * (_remainingDashDuration + Time.deltaTime) / Time.deltaTime;
            }

            _currentDashCount--;
            _movementState = MovementState.Default;

            return move;
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
                
                case MovementAction.Dash:
                    _dashState = DashState.Active;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }

        public IEnumerator DashRegeneration()
        {
            _isDashRegenerationActive = true;
            
            while (_currentDashCount < maxDashCount)
            {
                yield return new WaitForSeconds(oneDashRegenDuration);
                _currentDashCount++;
            }

            _isDashRegenerationActive = false;
        }
    }
    
    public enum MovementState
    {
        Default,
        Dash,
    }

    public enum MoveState
    {
        None,
        Move,
        Sprint,
    }
    
    public enum DashState
    {
        None,
        Active,
    }
}
