using _Project.Code.Gameplay;
using _Project.Code.Infrastructure.Systems;
using UnityEngine;
using Zenject;

namespace _Project.Code.Infrastructure
{
    public class EcsRunner : MonoBehaviour
    {
        private GameFeature _gameFeature;
        private GameFixedFeature _gameFixedFeature;
        private ISystemsFactory _systems;

        private void Start()
        {
            _gameFeature = new GameFeature(_systems);
            _gameFixedFeature = new GameFixedFeature(_systems);
            _gameFeature.Initialize();
            _gameFixedFeature.Initialize();
            Debug.Log("Vova its a banana");
        }

        private void Update()
        {
            _gameFeature.Execute();
            _gameFeature.Cleanup();
        }

        private void FixedUpdate()
        {
            _gameFixedFeature.Execute();
            _gameFixedFeature.Cleanup();
        }

        private void OnDestroy()
        {
            _gameFeature.TearDown();
            _gameFixedFeature.TearDown();
        }

        [Inject]
        public void Construct(ISystemsFactory systems)
        {
            _systems = systems;
            Debug.Log("Ilya its a car");
        }
    }
}