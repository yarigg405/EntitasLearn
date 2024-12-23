using Assets.Code.Meta.UI.GoldHolder.Systems;
using Assets.Code.Meta.UI.Shop;
using Assets.Code.Meta.UI.Shop.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Meta
{
    public class HomeUiFeature : Feature
    {
        public HomeUiFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializePurchasedItemsSystem>());

            Add(systems.Create<RefreshGoldGainBoostSystem>());
            Add(systems.Create<RefreshGoldSystem>());

            Add(systems.Create<ShopFeature>());
        }
    }
}
