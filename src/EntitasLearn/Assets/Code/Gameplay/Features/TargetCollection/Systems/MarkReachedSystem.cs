using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.TargetCollection.Systems
{
    internal sealed class MarkReachedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(64);

        internal MarkReachedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetsBuffer
            )
                .NoneOf(GameMatcher.Reached));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                if (entity.TargetsBuffer.Count > 0)
                    entity.isReached = true;
            }
        }
    }
}