using System;
using _Project.Code.Unused.PubSubUnused;
using _Project.Code.Unused.TopicsUnused.GeneralUnused;
using UnityEngine;

namespace _Project.Code.Unused.ScriptsUnused.CharacterUnused
{
    [Obsolete("Unused.")]
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