using Assets.Code.Meta.UI.Shop.Service;
using Entitas;
using System.Linq;


namespace Assets.Code.Meta.UI.Shop.Systems
{
    public class InitializePurchasedItemsSystem : IInitializeSystem
    {
        private readonly IGroup<MetaEntity> _purchasedItems;
        private readonly IShopUiService _shopUiService;

        public InitializePurchasedItemsSystem(MetaContext meta, IShopUiService shopUiService)
        {
            _purchasedItems = meta.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.ShopItemId,
                MetaMatcher.Purchased));
            _shopUiService = shopUiService;
        }

        void IInitializeSystem.Initialize()
        {
            _shopUiService
                .UpdatePurchasedItems(_purchasedItems.GetEntities()
                .Select(x => x.ShopItemId));
        }
    }
}
