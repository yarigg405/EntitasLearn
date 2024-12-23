using Assets.Code.Meta.UI.Shop.Systems;
using Assets.Code.Progress.SaveLoad;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Meta.UI.Shop
{
    internal class ProcessBoughtItemsSystem : ReactiveSystem<MetaEntity>
    {
        private readonly ShopItemFactory _shopItemFactory;
        private readonly ISaveLoadService _saveLoad;

        public ProcessBoughtItemsSystem(
            MetaContext meta,
            ShopItemFactory shopItemFactory,
            ISaveLoadService saveLoad) : base(meta)
        {
            _shopItemFactory = shopItemFactory;
            _saveLoad = saveLoad;
        }

        protected override bool Filter(MetaEntity entity)
        {
            return entity.hasShopItemId;
        }

        protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
        {
            return context.CreateCollector(MetaMatcher.Purchased.Added());
        }

        protected override void Execute(List<MetaEntity> purchases)
        {
            foreach (var purchase in purchases)
            {
                _shopItemFactory.CreateShopItem(purchase.ShopItemId);

                _saveLoad.SaveProgress();
            }
        }
    }
}
