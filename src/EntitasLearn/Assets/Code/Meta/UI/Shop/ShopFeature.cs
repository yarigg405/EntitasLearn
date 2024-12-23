using Assets.Code.Meta.UI.Shop.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Meta.UI.Shop
{
    internal class ShopFeature : Feature
    {
        public ShopFeature(ISystemFactory systems)
        {
            Add(systems.Create<BuyItemOnRequestSystem>());
            Add(systems.Create<ProcessBoughtItemsSystem>());
        }
    }
}
