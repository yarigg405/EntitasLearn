using Code.Gameplay.Common.Time;
using Entitas;


namespace Assets.Code.Gameplay.Features.TargetCollection.Systems
{
    internal sealed class CollectTargetsIntervalSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _entities;


        public CollectTargetsIntervalSystem(GameContext context, ITimeService time)
        {
            _time = time;
            _entities = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetsBuffer,
                GameMatcher.CollectTargetsInterval,
                GameMatcher.CollectTargetsTimer
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities)
            {
                entity.ReplaceCollectTargetsTimer(entity.CollectTargetsTimer - _time.DeltaTime);

                if (entity.CollectTargetsTimer <= 0)
                {
                    entity.isIsReadyToCollectTargets = true;
                    entity.ReplaceCollectTargetsTimer(entity.CollectTargetsInterval);
                }
            }
        }
    }
}
