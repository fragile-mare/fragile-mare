using _Project.Code.Infrastructure.Scenes;
using UnityEngine;

namespace _Project.Code.Infrastructure.States.GameStates
{
    public class LoadLevelState : IState
    {
        private const string CharacterPath = "Character/character";
        private readonly ISceneLoader _sceneLoader;
        
        public LoadLevelState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
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
            CreateCharacter();
        }

        public void CreateCharacter()
        {
            var initialPosition = Vector3.zero;
            var initialRotation = Quaternion.identity;
            
            var startPoint = GameObject.FindWithTag("StartPoint");
            if (startPoint != null)
            {
                initialPosition = startPoint.transform.position;
                initialRotation = startPoint.transform.rotation;
            }
            
            var characterPrefab = Resources.Load<GameObject>(CharacterPath);
            Object.Instantiate(characterPrefab, initialPosition, initialRotation);
        }
    }
}