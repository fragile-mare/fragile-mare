using _Project.Code.Infrastructure.Scenes;
using UnityEngine.SceneManagement;

namespace _Project.Code.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private const string Initial = "Initial";
        private const string Desert = "Desert";

        public BootstrapState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(Desert);
        }

        public void Exit()
        {
            
        }
    }
}