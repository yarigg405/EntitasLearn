using Assets.Code.Gameplay;
using Assets.Code.Infrastructure.States.GameStates;
using Code.Infrastructure.Systems;


namespace Code.Infrastructure.States.GameStates
{
    public class BattleLoopState : EndOfFrameExitState
    {
        private readonly ISystemFactory _systems;
        private readonly GameContext _game;
        private BattleFeature _battleFeature;

        public BattleLoopState(ISystemFactory systems, GameContext game)
        {
            _systems = systems;
            _game = game;
        }

        public override void Enter()
        {
            _battleFeature = _systems.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();       
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        protected override void ExitOnEndFrame()
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