using Assets.Code.Gameplay.Features.Statuses.Applier;
using Entitas;


namespace Assets.Code.Gameplay.Features.Loot.Systems
{
    internal sealed class CollectStatusItemSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _collected;
        private readonly IGroup<GameEntity> _heroes;
        private readonly StatusApplier _statusApplier;

        internal CollectStatusItemSystem(GameContext game, StatusApplier statusApplier)
        {
            _statusApplier = statusApplier;
            _collected = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Collected,
                GameMatcher.StatusSetups
            ));

            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Id,
                GameMatcher.Transform
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var hero in _heroes)
                foreach (var collected in _collected)
                    foreach (var status in collected.StatusSetups)
                    {
                        _statusApplier.ApplyStatus(status, hero.Id, hero.Id);
                    }
        }
    }
}