using _Project.Code.Infrastructure.Scenes;

namespace _Project.Code.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private readonly ISceneLoader _sceneLoader;


        public LoadLevelState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(ScenesNames.Desert);
        }

        public void Exit()
        {
            
        }
    }
}