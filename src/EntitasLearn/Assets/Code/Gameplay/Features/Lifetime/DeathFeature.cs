using Assets.Code.Gameplay.Features.Lifetime.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.Lifetime
{
    internal sealed class DeathFeature : Feature
    {
        public DeathFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkDeadSystem>());
            Add(systems.Create<UnapplyStatusesOnDeadTargetSystem>());
        }
    }
}
