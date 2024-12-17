using Assets.Code.Meta;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;


namespace Code.Infrastructure.States.GameStates
{
    public class HomeScreenState : IState, IUpdateable
    {
        private readonly ISystemFactory _systems;
        private readonly GameContext _game;
        private HomeScreenFeature _homeScreenFeature;

        public HomeScreenState(ISystemFactory systems, GameContext game)
        {
            _systems = systems;
            _game = game;
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