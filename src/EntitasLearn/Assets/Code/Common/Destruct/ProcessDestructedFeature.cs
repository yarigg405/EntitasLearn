using Assets.Code.Common.Destruct.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Common.Destruct
{
    internal sealed class ProcessDestructedFeature:Feature
    {
        public ProcessDestructedFeature(ISystemFactory systems)
        {
            Add(systems.Create<SelfDestructTimerSystem>());

            Add(systems.Create<CleanupMetaDestructedSystem>());

            Add(systems.Create<CleanupGameDestructedViewsSystem>());
            Add(systems.Create<CleanupGameDestructedSystem>());                
        }
    }
}
