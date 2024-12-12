using Assets.Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.TargetCollection
{
    internal sealed class CollectTargetsFeature : Feature
    {
        public CollectTargetsFeature(ISystemFactory systems)
        {
            Add(systems.Create<CollectTargetsIntervalSystem>());

            Add(systems.Create<CastForTargetsNoLimitsSystem>());
            Add(systems.Create<CastForTargetsWithLimitSystem>());
            Add(systems.Create<MarkReachedSystem>());

            Add(systems.Create<CleanupTargetBuffersSystem>());
        }
    }
}
