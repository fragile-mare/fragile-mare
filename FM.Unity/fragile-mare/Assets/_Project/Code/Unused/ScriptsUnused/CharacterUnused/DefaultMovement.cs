using System;
using System.Collections;
using _Project.Code.Unused.PubSubUnused;
using _Project.Code.Unused.TopicsUnused.GeneralUnused;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = _Project.Code.Unused.UtilsUnused.WDebugUnused.Debug;
using Vector3 = UnityEngine.Vector3;

namespace _Project.Code.Unused.ScriptsUnused.CharacterUnused
{
    [Obsolete("Unused.")]
    public class DefaultMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1f;
        
        [SerializeField]
        private float sprintSpeed = 1f;

        [FormerlySerializedAs("dashConfig")] [SerializeField] 
        private DashConfig dash;
        
        private Transform _targetTransform;

        private MovementState _movementState = MovementState.Default;

        private MoveState _forwardState = MoveState.None;
        private MoveState _backState = MoveState.None;
        private MoveState _rightState = MoveState.None;
        private MoveState _leftState = MoveState.None;

        private SprintState _sprintState = SprintState.None;

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

            _currentDashCount = dash.maxCount;

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
                _remainingDashDuration = dash.duration;
            }
            else if (_sprintState == SprintState.Active
                     && _movementState == MovementState.Default)
            {
                _movementState = MovementState.Sprint;
                _sprintState = SprintState.Active;
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
                case MovementState.Sprint:
                    move = SprintMove(move);
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

            _sprintState = SprintState.None;
            _dashState = DashState.None;
        }

        private void OnDestroy()
        {
            _playerActionsSub.Unsubscribe();
        }

        private Vector3 DefaultMove(Vector3 move)
        {
            Debug.Log(move.ToString());

            return move * speed;
        }
        
        private Vector3 SprintMove(Vector3 move)
        {
            _movementState = MovementState.Default;
            return move * sprintSpeed;
        }

        private Vector3 DashMove(Vector3 move)
        {
            move = move.normalized; // сделать то же самое со sprint и убрать этот normalized

            _remainingDashDuration -= Time.deltaTime;
            if (_remainingDashDuration > 0)
            {
                move *= dash.speed;
                return move;
            }
            
            if (_remainingDashDuration < 0 && Time.deltaTime > 0)
            {
                move *= dash.speed * (_remainingDashDuration + Time.deltaTime) / Time.deltaTime;
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
                MoveState.Move => direction,
                _ => Vector3.zero
            };
        }
        
        public void SetMoveState(MovementAction action)
        {
            switch (action)
            {
                case MovementAction.MoveForward or MovementAction.SprintForward:
                    _forwardState = MoveState.Move;
                    break;
                case MovementAction.MoveBack or MovementAction.SprintBack:
                    _backState = MoveState.Move;
                    break;
                case MovementAction.MoveRight or MovementAction.SprintRight:
                    _rightState = MoveState.Move;
                    break;
                case MovementAction.MoveLeft or MovementAction.SprintLeft:
                    _leftState = MoveState.Move;
                    break;
            }

            switch (action)
            {
                case MovementAction.MoveForward:
                case MovementAction.MoveBack:
                case MovementAction.MoveRight:
                case MovementAction.MoveLeft:
                    break;
                
                case MovementAction.SprintForward:
                case MovementAction.SprintBack:
                case MovementAction.SprintRight:
                case MovementAction.SprintLeft:
                    _sprintState = SprintState.Active;
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
            
            while (_currentDashCount < dash.maxCount)
            {
                yield return new WaitForSeconds(dash.oneRegenDuration);
                _currentDashCount++;
            }

            _isDashRegenerationActive = false;
        }
    }
    
    [Obsolete("Unused.")]
    public enum MovementState
    {
        Default,
        Sprint,
        Dash,
    }

    [Obsolete("Unused.")]
    public enum MoveState
    {
        None,
        Move,
    }
    
    [Obsolete("Unused.")]
    public enum SprintState
    {
        None,
        Active,
    }
    
    [Obsolete("Unused.")]
    public enum DashState
    {
        None,
        Active,
    }

    [Serializable]
    [Obsolete("Unused.")]
    public class DashConfig
    {
        [SerializeField] [Min(0f)] 
        public float duration;

        [SerializeField] [Min(0f)] 
        public float speed;

        [SerializeField] 
        public int maxCount;

        [SerializeField] [Min(0f)] 
        public float oneRegenDuration;
    }
}
