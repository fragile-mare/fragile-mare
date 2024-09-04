﻿using UnityEngine;

namespace _Project.Code.Gameplay.Cameras.Providers
{
    public class CameraProvider : ICameraProvider
    {
        private Vector3 _offset;
        public Camera MainCamera { get; private set; }
        
        public void SetMainCamera(Camera camera)
        {
            MainCamera = camera;
        }

        public void SetOffset(Vector3 offset)
        {
            var transform = MainCamera.transform;
            var position = transform.position;
            position = new Vector3(position.x, offset.y, position.z);
            transform.position = position;
            _offset = offset;
        }
        
        public Transform SetWorldXZ(float x, float z)
        {
            var transform = MainCamera.transform;
            transform.position = new Vector3(x + _offset.x, transform.position.y, z + _offset.z);
            return transform;
        }
    }
}