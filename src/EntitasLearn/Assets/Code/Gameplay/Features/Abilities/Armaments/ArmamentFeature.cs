using Assets.Code.Gameplay.Features.Abilities.Armaments.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.Abilities.Armaments
{
    internal sealed class ArmamentFeature : Feature
    {
        public ArmamentFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkProcessedOnTargetLimitExceededSystem>());
            Add(systems.Create<FollowProducerSystem>());
            Add(systems.Create<FinalizeProcessedArmamentsSystem>());
        }
    }
}
