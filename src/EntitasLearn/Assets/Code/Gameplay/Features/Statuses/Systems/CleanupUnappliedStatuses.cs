using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Statuses.Systems
{
    internal sealed class CleanupUnappliedStatuses : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);

        public CleanupUnappliedStatuses(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Status,
                GameMatcher.Unapplied
                ));
        }

        void ICleanupSystem.Cleanup()
        {
            foreach (var status in _statuses.GetEntities(_buffer))
            {

            }
        }
    }
}
