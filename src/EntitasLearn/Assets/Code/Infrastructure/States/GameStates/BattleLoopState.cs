using Assets.Code.Gameplay;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using System;


namespace Code.Infrastructure.States.GameStates
{
    public class BattleLoopState : IState, IUpdateable
    {
        private readonly ISystemFactory _systems;
        private readonly GameContext _game;
        private BattleFeature _battleFeature;

        public BattleLoopState(ISystemFactory systems, GameContext game)
        {
            _systems = systems;
            _game = game;
        }

        public void Enter()
        {
            _battleFeature = _systems.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        public void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        public void Exit()
        {
            _battleFeature.DeactivateReactiveSystems();
            _battleFeature.ClearReactiveSystems();

            DestructEntities();
            _battleFeature.Cleanup();

            _battleFeature.TearDown();
            _battleFeature = null;
        }

        private void DestructEntities()
        {
            foreach (var entity in _game.GetEntities())
                entity.isDestructed = true;
        }
    }
}