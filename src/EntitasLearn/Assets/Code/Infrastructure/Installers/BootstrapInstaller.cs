using Assets.Code.Gameplay.Common.Collisions;
using Assets.Code.Gameplay.Common.Physics;
using Assets.Code.Gameplay.Features.Enemies.Factory;
using Assets.Code.Gameplay.Features.Hero.Factory;
using Assets.Code.Infrastructure.Identifiers;
using Assets.Code.Infrastructure.View.Factory;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;
using Code.Gameplay.Levels;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Systems;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindInfrastructureServices();
            BindCommonServices();
            BindFactories();
            BindContexts();
            BindGameplayServices();
            BindCameraProvider();
        }


        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
            Container.Bind<InputContext>().FromInstance(Contexts.sharedInstance.input).AsSingle();
            Container.Bind<MetaContext>().FromInstance(Contexts.sharedInstance.meta).AsSingle();
        }

        private void BindCameraProvider()
        {
            Container.BindInterfacesAndSelfTo<CameraProvider>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
        }


        private void BindFactories()
        {
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();
            Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        }

        private void BindCommonServices()
        {
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
            Container.Bind<IPhysicsService>().To<PhysicsService>().AsSingle();
        }

        private void BindInputService()
        {
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }

        void IInitializable.Initialize()
        {

        }
    }
}