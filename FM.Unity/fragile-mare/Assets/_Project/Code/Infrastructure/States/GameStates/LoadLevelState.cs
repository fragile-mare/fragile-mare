using _Project.Code.Gameplay.Features.Character.Systems;
using _Project.Code.Infrastructure.Scenes;
using UnityEngine;

namespace _Project.Code.Infrastructure.States.GameStates
{
    public class LoadLevelState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ILevelDataProvider _levelDataProvider;

        public LoadLevelState(ISceneLoader sceneLoader, ILevelDataProvider levelDataProvider)
        {
            _sceneLoader = sceneLoader;
            _levelDataProvider = levelDataProvider;
        }

        public void Enter()
        {
            _sceneLoader.Load(ScenesNames.Desert, OnLevelLoaded);
        }
        
        public void Exit()
        {
            
        }

        public void OnLevelLoaded()
        {
            AdjustInitialPosition();
        }

        public void AdjustInitialPosition()
        {
            var initialPosition = Vector3.zero;
            var initialRotation = Quaternion.identity;
            
            var startPoint = GameObject.FindWithTag("StartPoint");
            if (startPoint != null)
            {
                initialPosition = startPoint.transform.position;
                initialRotation = startPoint.transform.rotation;
            }

            _levelDataProvider.SetStartPoint(initialPosition);
            _levelDataProvider.SetStartRotation(initialRotation);
        }
    }
}