using System;
using _Project.Code.Unused.PubSubUnused;
using _Project.Code.Unused.TopicsUnused.GeneralUnused;
using UnityEngine;

namespace _Project.Code.Unused.ScriptsUnused.PlayerUnused
{
    [Obsolete("Unused.")]
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] 
        private Transform cameraTransform;

        [SerializeField] 
        private Vector3 posOffset;

        [SerializeField] 
        private Vector3 rotationOffset;

        private bool _first = true;
        private Subscription _characterMovementSub;
        
        void Start()
        {
            var playerMovementTopic = MovementTopic.GetTopic("player.character");
            playerMovementTopic.Subscribe(@params =>
            {
                if (_first)
                {
                    cameraTransform.position = @params.OldPosition + posOffset;
                    cameraTransform.eulerAngles = rotationOffset;
                    _first = false;
                }
                
                cameraTransform.position += @params.Move;
            }, out _characterMovementSub);
        }
        
        private void OnDestroy()
        {
            _characterMovementSub.Unsubscribe();
        }
    }
}
