using Assets.Code.Gameplay.Features.Effects.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.Effects
{
    internal sealed class EffectsFeature : Feature
    {
        public EffectsFeature(ISystemFactory systems)
        {
            Add(systems.Create<RemoveEffectsWithoutTargetSystem>());
            Add(systems.Create<ProcessDamageEffecSystem>());
            Add(systems.Create<ProcessHealEffectSystem>());
            Add(systems.Create<CleanupProcessedEffects>());
        }
    }
}