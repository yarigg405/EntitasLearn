using Code.Infrastructure.Systems;
using Code.Meta.UI.Shop;

namespace Code.Meta
{
    public sealed class HomeUIFeature : Feature
  {
    public HomeUIFeature(ISystemFactory systems)
    {
     // Add(systems.Create<InitializePurchasedItemsSystem>());
      
//      Add(systems.Create<RefreshGoldGainBoostSystem>());
   //   Add(systems.Create<RefreshGoldSystem>());

      Add(systems.Create<ShopFeature>());
    }
  }
}