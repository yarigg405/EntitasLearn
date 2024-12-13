using Entitas;


namespace Assets.Code.Gameplay.Features.Loot.Systems
{
    internal sealed class CollectWhenNearSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullables;
        private readonly IGroup<GameEntity> _heroes;
        private readonly float _closeDistance = 0.4f;

        internal CollectWhenNearSystem(GameContext game)
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
                    if ((hero.Transform.position - pullable.Transform.position).sqrMagnitude <= _closeDistance)
                    {
                        pullable.isCollected = true;
                    }
                }
        }
    }
}