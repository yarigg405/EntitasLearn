﻿using Entitas;


namespace Assets.Code.Gameplay.Features.TargetCollection.Systems
{
    internal sealed class CleanupTargetBuffersSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CleanupTargetBuffersSystem(GameContext context)
        {
            _entities = context.GetGroup(GameMatcher.TargetsBuffer);
        }

        void ICleanupSystem.Cleanup()
        {
            foreach (var entity in _entities)
            {
                entity.TargetsBuffer.Clear();
            }
        }
    }
}
