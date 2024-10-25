using Assets.Code.Gameplay.Features.Statuses.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.Statuses
{
    internal sealed class StatusFeature: Feature
    {

        public StatusFeature(ISystemFactory systems)
        {
            Add(systems.Create<StatusDurationSystem>());
            Add(systems.Create<PeriodicDamageStatusSystem>());
            Add(systems.Create<StatusVisualsFeature>());

            Add(systems.Create<CleanupUnappliedStatuses>());
        }
    }
}
