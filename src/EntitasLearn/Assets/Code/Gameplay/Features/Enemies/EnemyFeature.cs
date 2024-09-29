using Assets.Code.Gameplay.Features.Enemies.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.Enemies
{
    internal sealed class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory systems)
        {
            Add(systems.Create<ChaseHeroSystem>());
            Add(systems.Create<EnemyDeathSystem>());

            Add(systems.Create<FinalizeEnemyDeathProcessingSystem>());
        }
    }
}
