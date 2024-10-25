using Assets.Code.Gameplay.Features.Statuses.Applier;
using Entitas;


namespace Assets.Code.Gameplay.Features.Statuses.Systems
{
    internal sealed class ApplyStatusesOnTargetsSystem : IExecuteSystem
    {
        private readonly StatusApplier _statusSpplier;
        private readonly IGroup<GameEntity> _entities;
        private readonly GameContext _gameContext;

        public ApplyStatusesOnTargetsSystem(GameContext context, StatusApplier statusApplier)
        {
            _gameContext = context;
            _statusSpplier = statusApplier;

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
                        _statusSpplier.ApplyStatus(setup, ProducerId(entity), targetId);
                    }
        }

        private int ProducerId(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
}
