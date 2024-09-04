using _Project.Code.Gameplay.Cameras.Providers;
using Entitas;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Project.Code.Infrastructure.Installers
{
    public class LevelInitializer : MonoBehaviour, IInitializable
    {
        public Camera mainCamera;
        private ICameraProvider _cameraProvider;
        public Vector3 offset;

        [Inject]
        private void Construct(ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
        }
        public void Initialize()
        {
            _cameraProvider.SetMainCamera(mainCamera);
            _cameraProvider.SetOffset(offset);
        }
    }
}