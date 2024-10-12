using Assets.Code.Gameplay.Common.Physics;
using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.TargetCollection.Systems
{
    internal sealed class CastForTargetsWithLimitSystem : IExecuteSystem, ITearDownSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IPhysicsService _physicsService;
        private readonly List<GameEntity> _buffer = new(64);
        private GameEntity[] _targetsBuffer = new GameEntity[64];

        internal CastForTargetsWithLimitSystem(GameContext context, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _entities = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.ReadyToCollectTargets,
                GameMatcher.TargetsBuffer,
                GameMatcher.ProcessedTargets,
                GameMatcher.TargetLimit,
                GameMatcher.Transform,
                GameMatcher.Radius,
                GameMatcher.LayerMask
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                for (int i = 0; i < Mathf.Min(entity.TargetLimit, TargetCountInRadius(entity)); i++)
                {
                    var targetId = _targetsBuffer[i].Id;

                    if (!AlreadyProcessed(entity, targetId))
                    {
                        entity.TargetsBuffer.Add(targetId);
                        entity.ProcessedTargets.Add(targetId);
                    }
                }               

                if (!entity.isCollectingTargetsContiniously)
                    entity.isReadyToCollectTargets = false;
            }
        }

        private bool AlreadyProcessed(GameEntity entity, int targetId)
        {
            return entity.ProcessedTargets.Contains(targetId);
        }

        private int TargetCountInRadius(GameEntity entity)
        {
            return _physicsService.SphereCastNonAlloc(entity.Transform.position, entity.Radius, entity.LayerMask, _targetsBuffer);
        }

        private IEnumerable<int> GetTargetsInRadius(GameEntity entity)
        {
            return
            _physicsService
            .SphereCast(entity.Transform.position, entity.Radius, entity.LayerMask)
            .Select(x => x.Id);
        }

        void ITearDownSystem.TearDown()
        {
            _targetsBuffer = null;
        }
    }
}