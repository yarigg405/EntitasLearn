using Assets.Code.Gameplay.Common.Physics;
using Entitas;
using System.Collections.Generic;
using System.Linq;


namespace Assets.Code.Gameplay.Features.TargetCollection.Systems
{
    internal sealed class CastForTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IPhysicsService _physicsService;
        private readonly List<GameEntity> _buffer = new(64);

        public CastForTargetsSystem(GameContext context, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _entities = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.IsReadyToCollectTargets,
                GameMatcher.TargetsBuffer,
                GameMatcher.Transform,
                GameMatcher.Radius,
                GameMatcher.LayerMask
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity.TargetsBuffer.AddRange(GetTargetsInRadius(entity));
                entity.isIsReadyToCollectTargets = false;
            }
        }

        private IEnumerable<int> GetTargetsInRadius(GameEntity entity)
        {
            return
            _physicsService
            .SphereCast(entity.Transform.position, entity.Radius, entity.LayerMask)
            .Select(x => x.Id);
        }
    }
}
