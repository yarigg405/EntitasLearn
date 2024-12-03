using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Statuses.Systems
{
    internal sealed class CleanupUnappliedStatusLinkedChanges : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);
        private readonly GameContext _game;

        internal CleanupUnappliedStatusLinkedChanges(GameContext game)
        {
            _game = game;
            _statuses = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Id,
                GameMatcher.Status,
                GameMatcher.Unapplied
            ));
        }

        void ICleanupSystem.Cleanup()
        {
            foreach (var status in _statuses.GetEntities(_buffer))
                foreach(var entity in _game.GetEntitiesWithApplierStatusLink(status.Id))
                    entity.isDestructed = true;
        }
    }
}