using Assets.Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.TargetCollection
{
    internal sealed class CollectTargetsFeature : Feature
    {
        public CollectTargetsFeature(ISystemFactory systems)
        {
            Add(systems.Create<CollectTargetsIntervalSystem>());
            Add(systems.Create<CastForTargetsSystem>());
            Add(systems.Create<CleanupTargetBuffersSystem>());
        }
    }
}
