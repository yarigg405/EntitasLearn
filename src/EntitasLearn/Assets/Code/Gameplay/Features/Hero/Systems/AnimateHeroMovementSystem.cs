using Entitas;


namespace Assets.Code.Gameplay.Features.Hero.Systems
{
    internal sealed class AnimateHeroMovementSystem:IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        internal AnimateHeroMovementSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
              .AllOf(
                GameMatcher.Hero,
                GameMatcher.HeroAnimator));
        }


        void IExecuteSystem.Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                if (hero.isMoving)
                    hero.HeroAnimator.PlayMove();
                else
                    hero.HeroAnimator.PlayIdle();
            }
        }
    }
}
