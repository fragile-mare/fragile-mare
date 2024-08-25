using System;
using src.pubsub;
using src.Topics.General;
using UnityEngine;

namespace src.Scripts.Character
{
    public class DefaultRotation : MonoBehaviour
    {
        [SerializeField] 
        private float rotationSpeed = 1000f;
        
        private Transform _targetTransform;

        private Subscription _rotationTopicSub;

        void Start()
        {
            var entity = GetComponentInParent<Entity>();
            if (entity == null)
            {
                Debug.LogError("Need to add Entity class into parent");
                return;
            }
            
            _targetTransform = entity.targetTransform;
            
            RotationActionsTopic.GetTopic(entity.topicPrefix).Subscribe(rotation =>
            {
                var oldRotation = _targetTransform.rotation;
                _targetTransform.rotation = 
                    Quaternion.RotateTowards(oldRotation, rotation, Time.deltaTime * rotationSpeed);
            }, out _rotationTopicSub);
        }

        private void OnDestroy()
        {
            _rotationTopicSub.Unsubscribe();
        }
    }
}