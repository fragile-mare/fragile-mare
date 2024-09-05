using System;
using _Project.Code.Gameplay;
using _Project.Code.Infrastructure.Systems;
using UnityEngine;
using Zenject;

namespace _Project.Code.Infrastructure
{
    public class EcsRunner : MonoBehaviour
    {
        private ISystemsFactory _systems;
        private GameFeature _gameFeature;

        [Inject]
        public void Construct(ISystemsFactory systems)
        {
            _systems = systems;
            Debug.Log("Ilya its a car");
        }

        private void Start()
        {
            _gameFeature = new GameFeature(_systems);
            _gameFeature.Initialize();
        }

        private void Update()
        {
            _gameFeature.Execute();
            _gameFeature.Cleanup();
        }

        private void OnDestroy()
        {
            _gameFeature.TearDown();
        }
    }
}