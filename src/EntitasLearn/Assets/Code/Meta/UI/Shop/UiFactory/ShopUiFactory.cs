using Assets.Code.Meta.UI.Shop.Items;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;


namespace Assets.Code.Meta.UI.Shop.UiFactory
{
    public class ShopUiFactory : IShopUiFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        private const string _shopItemPrefabPath = "UI/Home/ShopItem";

        public ShopUiFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public ShopItem CreateShopItem(ShopItemConfig config, Transform parent)
        {
            var shopItemPrefab = _assetProvider.LoadAsset<ShopItem>(_shopItemPrefabPath);
            var shopItem = _instantiator.InstantiatePrefabForComponent<ShopItem>(shopItemPrefab, parent);
            shopItem.Setup(config);

            return shopItem;
        }
    }
}
