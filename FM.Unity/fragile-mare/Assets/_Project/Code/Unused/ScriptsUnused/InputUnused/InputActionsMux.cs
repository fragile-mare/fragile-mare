using System;
using System.Collections.Generic;
using _Project.Code.Unused.PubSubUnused;
using _Project.Code.Unused.TopicsUnused.GeneralUnused;
using _Project.Code.Unused.TopicsUnused.PlayerUnused.Input;
using UnityEngine;
using Debug = _Project.Code.Unused.UtilsUnused.WDebugUnused.Debug;

namespace _Project.Code.Unused.ScriptsUnused.InputUnused
{
    [Obsolete("Unused.")]
    public class InputActionsMux : MonoBehaviour
    {
        private Subscription _playerActionsSub;
        private Topic<MovementAction> _movementActionsTopic;

        private readonly Dictionary<InputAction, MovementAction> _movementMapping = new()
        {
            {InputAction.MoveForward, MovementAction.MoveForward},
            {InputAction.MoveBack, MovementAction.MoveBack},
            {InputAction.MoveRight, MovementAction.MoveRight},
            {InputAction.MoveLeft, MovementAction.MoveLeft},
            
            {InputAction.SprintForward, MovementAction.SprintForward},
            {InputAction.SprintBack, MovementAction.SprintBack},
            {InputAction.SprintRight, MovementAction.SprintRight},
            {InputAction.SprintLeft, MovementAction.SprintLeft},
            
            {InputAction.Dash, MovementAction.Dash},
        };
        
        public void Start()
        {
            var entity = GetComponentInParent<Entity>();
            if (entity == null)
            {
                Debug.LogError("Need to add Entity class into parent");
                return;
            }
            
            CreateTopics(entity.topicPrefix);
            
            // todo: группировать разные действия игрока по топикам.
            // todo: передвижение - в один, бой - в другой и т.д.
            InputActionsTopic.Subscribe(@params =>
            {
                MapInputAction(@params.InputAction);
            }, out _playerActionsSub);
        }

        public void CreateTopics(string topicPrefix)
        {
            _movementActionsTopic = MovementActionsTopic.CreateTopic(topicPrefix);
        }

        public void MapInputAction(InputAction action)
        {
            if(_movementMapping.TryGetValue(action, out var movementAction))
            {
                Send(movementAction);
                return;
            }
                
            Debug.LogError($"mappings dont have \"{action}\" input action.");
        }
        
        public void Send(MovementAction movementAction)
        {
            _movementActionsTopic.Publish(movementAction);
        }

        private void OnDestroy()
        {
            _playerActionsSub.Unsubscribe();
        }
    }
}