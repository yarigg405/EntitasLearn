using Assets.Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.GameOver.Systems
{
    internal class GameOverOnHeroDeathSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGameStateMachine _stateMachine;

        public GameOverOnHeroDeathSystem(GameContext game, IGameStateMachine stateMachine) : base(game)
        {
            _stateMachine = stateMachine;
        }


        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(
                  GameMatcher.Hero,
                  GameMatcher.Dead
                  ).Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isDead;
        }

        protected override void Execute(List<GameEntity> heroes)
        {
            _stateMachine.Enter<GameOverState>();
        }
    }
}
