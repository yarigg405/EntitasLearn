using Entitas;


namespace Assets.Code.Gameplay.Features.Loot.Systems
{
    internal sealed class PoolTowardsHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullables;
        private readonly IGroup<GameEntity> _heroes;

        internal PoolTowardsHeroSystem(GameContext game)
        {
            _pullables = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Pulling,
                GameMatcher.Transform
            ));

            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Transform
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var hero in _heroes)
                foreach (var pullable in _pullables)
                {
                    pullable.ReplaceDirection((hero.Transform.position - pullable.Transform.position).normalized);
                    pullable.ReplaceSpeed(4f);
                    pullable.isMoving = true;
                    pullable.isMovementAvailable = true;
                }
        }
    }
}