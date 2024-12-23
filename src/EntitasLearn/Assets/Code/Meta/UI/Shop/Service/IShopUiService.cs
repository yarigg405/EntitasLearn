using Assets.Code.Meta.UI.Shop.Items;
using System;
using System.Collections.Generic;

namespace Assets.Code.Meta.UI.Shop.Service
{
    public interface IShopUiService
    {
        event Action ShopChanged;

        void Cleanup();
        List<ShopItemConfig> GetAvailableShopItems();
        ShopItemConfig GetConfig(ShopItemId shopItemId);
        void UpdatePurchasedItems(IEnumerable<ShopItemId> purchasedItems);
        void UpdatePurchasedItem(ShopItemId shopItemId);

    }
}