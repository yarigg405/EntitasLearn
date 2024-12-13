using Assets.Code.Gameplay.Features.LevelUp.Systems;
using Assets.Code.Gameplay.Features.Loot.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.Loot
{
    internal class LootFeature : Feature
    {
        public LootFeature(ISystemFactory systems)
        {
            Add(systems.Create<CastForPullablesSystem>());

            Add(systems.Create<PoolTowardsHeroSystem>());
            Add(systems.Create<CollectWhenNearSystem>());
            Add(systems.Create<CollectExperienceSystem>());
            Add(systems.Create<CollectEffectItemSystem>());
            Add(systems.Create<CollectStatusItemSystem>());

            Add(systems.Create<UpdateExperienceMeterSystem>());

            Add(systems.Create<CleanupCollectedSystem>());
        }
    }
}
