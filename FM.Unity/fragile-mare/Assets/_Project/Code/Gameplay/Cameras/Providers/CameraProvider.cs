using _Project.Code.Common.Extensions;
using UnityEngine;

namespace _Project.Code.Gameplay.Cameras.Providers
{
    public class CameraProvider : ICameraProvider
    {
        private Vector3 _offset;

        private Vector3 _cursorVector;
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
            return MainCamera.transform.SetWorldXZ(x + _offset.x, z + _offset.z);
        }

        public void SetRotation(float xRotation, float yRotation, float zRotation)
        {
            MainCamera.transform.localRotation =
                Quaternion.Euler(xRotation, yRotation, zRotation);
        }
        
        public void SetCameraRotation(float x, float y, float z)
        {
            MainCamera.transform.localEulerAngles = new Vector3(x, y, z);
        }

        public void SetPosition(Vector3 position)
        {
            MainCamera.transform.position = position;
        }

        public float GetCameraLocalY()
        {
            return MainCamera.transform.localEulerAngles.y;
        }

        public Quaternion GetLocalRotation()
        {
            return MainCamera.transform.localRotation;
        }
        
    }
}