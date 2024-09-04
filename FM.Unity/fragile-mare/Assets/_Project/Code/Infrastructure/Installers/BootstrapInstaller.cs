using _Project.Code.Common.Services.Time;
using _Project.Code.Gameplay.Cameras.Providers;
using _Project.Code.Gameplay.Input.Services;
using _Project.Code.Infrastructure.States;
using _Project.Code.Infrastructure.Systems;
using Zenject;

namespace _Project.Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game);
            
            Container.Bind<ISystemsFactory>().To<SystemsFactory>().AsSingle();
            
            BindServices();
            BindGameStates();

            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindGameStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<IInputAxisService>().To<InputAxisService>().AsSingle();
            Container.Bind<IInputButtonService>().To<InputButtonService>().AsSingle();
                
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }
    }
}