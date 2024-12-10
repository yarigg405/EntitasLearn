using Assets.Code.Gameplay.Features.Statuses.Applier;
using Entitas;


namespace Assets.Code.Gameplay.Features.Statuses.Systems
{
    internal sealed class ApplyStatusesOnTargetsSystem : IExecuteSystem
    {
        private readonly StatusApplier _statusApplier;
        private readonly IGroup<GameEntity> _entities;

        public ApplyStatusesOnTargetsSystem(GameContext context, StatusApplier statusApplier)
        {
            _statusApplier = statusApplier;

            _entities = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.StatusSetups,
                GameMatcher.TargetsBuffer
                ));
        }
        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities)
                foreach (var targetId in entity.TargetsBuffer)
                    foreach (var setup in entity.StatusSetups)
                    {
                        _statusApplier.ApplyStatus(setup, ProducerId(entity), targetId);
                    }
        }

        private int ProducerId(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
}
