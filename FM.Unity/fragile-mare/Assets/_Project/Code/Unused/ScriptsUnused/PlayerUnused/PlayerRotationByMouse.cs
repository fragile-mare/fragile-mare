using System;
using _Project.Code.Unused.PubSubUnused;
using _Project.Code.Unused.TopicsUnused.GeneralUnused;
using UnityEngine;

namespace _Project.Code.Unused.ScriptsUnused.PlayerUnused
{
    [Obsolete("Unused.")]
    public class PlayerRotationByMouse : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera; 
    
        private Transform _playerTransform;
    
        private Vector3 _oldRotation = Vector3.zero;

        private Topic<Quaternion> _rotationActionsTopic;
    
        void Start()
        {
            if (playerCamera == null) playerCamera = Camera.main;
        
            var entity = GetComponentInParent<Entity>();
            if (entity == null)
            {
                Debug.LogError("Need to add Entity class into parent");
                return;
            }

            _playerTransform = entity.targetTransform;
            _rotationActionsTopic = RotationActionsTopic.CreateTopic(entity.topicPrefix);
        }
    
        void Update()
        {
            var mouseRotation = UnityEngine.Input.mousePosition;
            if (_oldRotation == mouseRotation) return;
        
            var positionOnScreen = (Vector2) playerCamera.WorldToViewportPoint(_playerTransform.position);
            var mouseOnScreen = (Vector2) playerCamera.ScreenToViewportPoint(mouseRotation);
		
            var angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            _oldRotation = mouseRotation;
        
            var wantedRotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
            _rotationActionsTopic.Publish(wantedRotation);
        }
    
        private static float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
            return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
        }
    }
}
