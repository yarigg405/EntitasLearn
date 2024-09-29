using Assets.Code.Gameplay.Features.DamageApplication.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.DamageApplication
{
    internal sealed class DamageApplicationFeature : Feature
    {
        public DamageApplicationFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyDamageOnTargetsSystem>());
        }
    }
}
