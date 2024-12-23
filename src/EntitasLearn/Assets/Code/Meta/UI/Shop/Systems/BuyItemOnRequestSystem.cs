using Assets.Code.Meta.UI.Shop.Items;
using Assets.Code.Meta.UI.Shop.Service;
using Code.Common.Entity;
using Entitas;


namespace Assets.Code.Meta.UI.Shop.Systems
{
    internal sealed class BuyItemOnRequestSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _requests;
        private readonly IGroup<MetaEntity> _storages;
        private readonly IShopUiService _shopUiService;

        internal BuyItemOnRequestSystem(MetaContext meta, IShopUiService shopUiService)
        {
            _shopUiService = shopUiService;

            _storages = meta.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.Storage,
                MetaMatcher.Gold
                ));


            _requests = meta.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.BuyRequest,
                MetaMatcher.ShopItemId
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var storage in _storages)
                foreach (var request in _requests)
                {
                    var config = _shopUiService.GetConfig(request.ShopItemId);

                    if (storage.Gold >= config.Price)
                    {
                        storage.ReplaceGold(storage.Gold - config.Price);
                        CreateMetaEntity.Empty()
                            .AddShopItemId(request.ShopItemId)
                            .isPurchased = true
                            ;

                        _shopUiService.UpdatePurchasedItem(request.ShopItemId);
                    }

                    request.isDestructed = true;
                }
        }
    }
}