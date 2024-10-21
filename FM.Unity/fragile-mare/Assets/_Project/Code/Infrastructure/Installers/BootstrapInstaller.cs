using _Project.Code.Common.Services.Assets;
using _Project.Code.Common.Services.Collisions;
using _Project.Code.Common.Services.Identifiers;
using _Project.Code.Common.Services.Physics;
using _Project.Code.Common.Services.StaticData;
using _Project.Code.Common.Services.Time;
using _Project.Code.Gameplay.Cameras.Providers;
using _Project.Code.Gameplay.Features.Ability.Factories;
using _Project.Code.Gameplay.Features.Character.Factory;
using _Project.Code.Gameplay.Features.Character.Systems;
using _Project.Code.Gameplay.Features.Dummy.Factory;
using _Project.Code.Gameplay.Features.Effect.Factories;
using _Project.Code.Gameplay.Features.Status.Factories;
using _Project.Code.Gameplay.Input.Axis.Services;
using _Project.Code.Gameplay.Input.Button.Services;
using _Project.Code.Gameplay.Input.Controls.Services;
using _Project.Code.Gameplay.Input.Cursor.Services;
using _Project.Code.Gameplay.Input.Scroll.Services;
using _Project.Code.Infrastructure.Scenes;
using _Project.Code.Infrastructure.States.Factory;
using _Project.Code.Infrastructure.States.GameStates;
using _Project.Code.Infrastructure.States.StateMachine;
using _Project.Code.Infrastructure.Systems;
using _Project.Code.Infrastructure.View.Factory;
using Zenject;

namespace _Project.Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();

            Container.Resolve<IStaticDataService>().LoadAll();
        }

        public override void InstallBindings()
        {
            BindInstallers();
            BindStateMachine();
            BindContexts();
            BindFactories();
            BindLoaders();
            BindGameStates();
            BindServices();
            BindGameplayFactories();
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

        private void BindGameplayFactories()
        {
            Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();
            Container.Bind<IDummyFactory>().To<DummyFactory>().AsSingle();
            Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
            Container.Bind<IEffectFactory>().To<EffectFactory>().AsSingle();
            Container.Bind<IStatusFactory>().To<StatusFactory>().AsSingle();
            Container.Bind<IAbilityFactory>().To<AbilityFactory>().AsSingle();
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
            Container.Bind<IIdentifierService>().To<SequenceIdentifierService>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
            Container.Bind<ICursorPositionService>().To<CursorPositionService>().AsSingle();
            Container.Bind<IScrollPositionService>().To<ScrollPositionService>().AsSingle();
            Container.Bind<IDefaultControlsProvider>().To<DefaultControlsProvider>().AsSingle();
        }
    }
}