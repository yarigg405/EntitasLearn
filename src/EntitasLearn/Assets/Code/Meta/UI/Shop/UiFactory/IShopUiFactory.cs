using Assets.Code.Meta.UI.Shop.Items;
using UnityEngine;

namespace Assets.Code.Meta.UI.Shop.UiFactory
{
    public interface IShopUiFactory
    {
        ShopItem CreateShopItem(ShopItemConfig config, Transform parent);
    }
}