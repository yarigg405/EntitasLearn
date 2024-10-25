using Assets.Code.Gameplay.Features.EffectApplication.Systems;
using Assets.Code.Gameplay.Features.Statuses.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.DamageApplication
{
    internal sealed class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyEffectsOnTargetsSystem>());
            Add(systems.Create<ApplyStatusesOnTargetsSystem>());
        }
    }
}
