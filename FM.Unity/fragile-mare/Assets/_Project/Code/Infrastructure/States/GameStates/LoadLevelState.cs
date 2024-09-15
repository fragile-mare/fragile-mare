using _Project.Code.Gameplay.Features.Character.Systems;
using _Project.Code.Infrastructure.Scenes;

namespace _Project.Code.Infrastructure.States.GameStates
{
    public class LoadLevelState : IState
    {
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly ISceneLoader _sceneLoader;

        public LoadLevelState(ISceneLoader sceneLoader, ILevelDataProvider levelDataProvider)
        {
            _sceneLoader = sceneLoader;
            _levelDataProvider = levelDataProvider;
        }

        public void Enter()
        {
            _levelDataProvider.Refresh();
            _sceneLoader.Load(ScenesNames.Desert, OnLevelLoaded);
        }

        public void Exit()
        {
        }

        public void OnLevelLoaded()
        {
        }
    }
}