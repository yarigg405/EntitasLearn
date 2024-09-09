using Entitas;
using UnityEngine;


namespace Assets.Code.Common.Destruct.Systems
{
    internal sealed class CleanupGameDestructedViewsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CleanupGameDestructedViewsSystem(GameContext context)
        {
            _entities = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.Destructed,
                GameMatcher.View));
        }

        void ICleanupSystem.Cleanup()
        {
            foreach (var entity in _entities)
            {
                entity.View.ReleaseEntity();
                Object.Destroy(entity.View.gameObject);
            }
        }
    }
}
