using System.Collections;
using _Project.Code.Common.Services.Time;
using _Project.Code.Gameplay.Cameras.Providers;
using _Project.Code.Gameplay.Input.Axis.Services;
using _Project.Code.Gameplay.Input.Button.Services;
using _Project.Code.Infrastructure.Scenes;
using _Project.Code.Infrastructure.States;
using _Project.Code.Infrastructure.Systems;
using Zenject;

namespace _Project.Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game);
            Container.Bind<ISystemsFactory>().To<SystemsFactory>().AsSingle();

            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();

            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            
            BindServices();
            BindGameStates();
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