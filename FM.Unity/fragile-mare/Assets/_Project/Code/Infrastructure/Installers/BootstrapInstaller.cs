using _Project.Code.Common.Services.Time;
using _Project.Code.Gameplay.Cameras.Providers;
using _Project.Code.Gameplay.Input.Axis.Services;
using _Project.Code.Gameplay.Input.Button.Services;
using _Project.Code.Infrastructure.Scenes;
using _Project.Code.Infrastructure.States.Factory;
using _Project.Code.Infrastructure.States.GameStates;
using _Project.Code.Infrastructure.States.StateMachine;
using _Project.Code.Infrastructure.Systems;
using Zenject;

namespace _Project.Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindInstallers();
            BindStateMachine();
            BindContexts();
            BindFactories();
            BindLoaders();
            BindGameStates();
            BindServices();
        }

        private void BindInstallers()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }

        private void BindContexts()
        {
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game);
        }

        private void BindFactories()
        {
            Container.Bind<ISystemsFactory>().To<SystemsFactory>().AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
        }

        private void BindLoaders()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<IInputAxisService>().To<InputAxisService>().AsSingle();
            Container.Bind<IInputButtonService>().To<AllInputButtonService>().AsSingle();
            
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }
    }
}