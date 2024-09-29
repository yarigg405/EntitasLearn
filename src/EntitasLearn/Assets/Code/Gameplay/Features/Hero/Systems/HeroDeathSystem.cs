using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Hero.Systems
{
    internal sealed class HeroDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public HeroDeathSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Dead,
                GameMatcher.HeroAnimator,
                GameMatcher.ProcessingDeath
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var hero in _heroes)
            {
                hero.isMovementAvailable = false;
                hero.HeroAnimator.PlayDie();
                hero.Rigidbody.velocity = Vector3.zero;
            }
        }
    }
}
