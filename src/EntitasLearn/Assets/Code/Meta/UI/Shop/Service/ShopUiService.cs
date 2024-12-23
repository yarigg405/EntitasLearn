using Assets.Code.Meta.UI.Shop.Items;
using Code.Gameplay.StaticData;
using System;
using System.Collections.Generic;


namespace Assets.Code.Meta.UI.Shop.Service
{
    public class ShopUiService : IShopUiService
    {
        private readonly List<ShopItemId> _purchasedItems = new();
        private readonly Dictionary<ShopItemId, ShopItemConfig> _availableItems = new();
        private readonly StaticDataService _staticData;

        public event Action ShopChanged;

        public ShopUiService(StaticDataService staticData)
        {
            _staticData = staticData;
        }

        public void UpdatePurchasedItems(IEnumerable<ShopItemId> purchasedItems)
        {
            _purchasedItems.AddRange(purchasedItems);

            RefreshAvailableItems();
        }

        public void UpdatePurchasedItem(ShopItemId shopItemId)
        {
            _availableItems.Remove(shopItemId);
            _purchasedItems.Add(shopItemId);

            ShopChanged?.Invoke();
        }

        public List<ShopItemConfig> GetAvailableShopItems()
        {
            return new(_availableItems.Values);
        }

        public void Cleanup()
        {
            _purchasedItems.Clear();
            _availableItems.Clear();

            ShopChanged = null;
        }

        private void RefreshAvailableItems()
        {
            foreach (var item in _staticData.GetShopItemConfigs())
            {
                if (!_purchasedItems.Contains(item.ShopItemId))
                    _availableItems.Add(item.ShopItemId, item);
            }

            ShopChanged?.Invoke();
        }

        public ShopItemConfig GetConfig(ShopItemId shopItemId)
        {
            return _availableItems.GetValueOrDefault(shopItemId);
        }
    }
}
