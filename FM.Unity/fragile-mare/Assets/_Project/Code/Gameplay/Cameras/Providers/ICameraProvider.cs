using UnityEngine;

namespace _Project.Code.Gameplay.Cameras.Providers
{
    public interface ICameraProvider
    {
        Camera MainCamera { get; }
        
        void SetMainCamera(Camera camera);
        void SetOffset(Vector3 offset);
        void SetRotation(float xRotation, float yRotation, float zRotation);
        void SetCameraRotation(float xRotation, float yRotation, float zRotation);
        void SetPosition(Vector3 position);
        void SetCameraRotationX(float x);
        void SetCameraRotationY(float y);
        
        Quaternion GetLocalRotation();
        Transform SetWorldXZ(float x, float z);
        Vector3 GetCameraPositionXZ();
        float GetCameraLocalY();
    }
}