using UnityEngine;

namespace _Project.Code.Gameplay.Cameras.Providers
{
    public interface ICameraProvider
    {
        Camera MainCamera { get; }
        void SetMainCamera(Camera camera);
        void SetOffset(Vector3 offset);
        Transform SetWorldXZ(float x, float z);
        void SetRotation(float xRotation, float yRotation, float zRotation);
        void SetCameraRotation(float xRotation, float yRotation, float zRotation);
        void SetPosition(Vector3 position);
        float GetCameraLocalY();
        Quaternion GetLocalRotation();
        void SetCameraRotationX(float x);
        void SetCameraRotationY(float y);
    }
}