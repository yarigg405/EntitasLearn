using Assets.Code.Common.Destruct;
using Code.Infrastructure.Systems;


namespace Assets.Code.Meta
{
    public class HomeScreenFeature : Feature
    {
        public HomeScreenFeature(ISystemFactory systems)
        {
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}
