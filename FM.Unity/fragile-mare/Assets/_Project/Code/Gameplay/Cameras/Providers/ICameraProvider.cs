using UnityEngine;

namespace _Project.Code.Gameplay.Cameras.Providers
{
    public interface ICameraProvider
    {
        Camera MainCamera { get; }
        void SetMainCamera(Camera camera);
        void SetOffset(Vector3 offset);
        Transform SetWorldXZ(float x, float z);
    }
}