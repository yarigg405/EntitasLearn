using Assets.Code.Infrastructure.View.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Infrastructure.View
{
    internal sealed class BindViewFeature : Feature
    {
        public BindViewFeature(ISystemFactory systems)
        {
            Add(systems.Create<BindEntityViewFromPathSystem>());
            Add(systems.Create<BindEntityViewFromPrefabSystem>());
        }
    }
}
