using Assets.Code.Meta;
using Assets.Code.Meta.UI.GoldHolder.Service;
using Assets.Code.Meta.UI.Shop.Service;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;


namespace Code.Infrastructure.States.GameStates
{
    public class HomeScreenState : IState, IUpdateable
    {
        private readonly ISystemFactory _systems;
        private readonly GameContext _game;
        private readonly StorageUIService _storage;
        private readonly IShopUiService _shopUiService;
        private HomeScreenFeature _homeScreenFeature;

        public HomeScreenState(
            ISystemFactory systems,
            GameContext game,
            StorageUIService storage,
            IShopUiService shopUiService)
        {
            _systems = systems;
            _game = game;
            _storage = storage;
            _shopUiService = shopUiService;
        }

        public void Enter()
        {
            _homeScreenFeature = _systems.Create<HomeScreenFeature>();
            _homeScreenFeature.Initialize();
        }

        public void Update()
        {
            _homeScreenFeature.Execute();
            _homeScreenFeature.Cleanup();
        }

        public void Exit()
        {
            _shopUiService.Cleanup();

            _homeScreenFeature.DeactivateReactiveSystems();
            _homeScreenFeature.ClearReactiveSystems();

            DestructEntities();
            _homeScreenFeature.Cleanup();

            _homeScreenFeature.TearDown();
            _homeScreenFeature = null;
        }

        private void DestructEntities()
        {
            foreach (var entity in _game.GetEntities())
                entity.isDestructed = true;
        }
    }
}