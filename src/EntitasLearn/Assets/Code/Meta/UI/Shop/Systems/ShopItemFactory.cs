using Assets.Code.Infrastructure.Identifiers;
using Assets.Code.Meta.UI.Shop.Items;
using Code.Common.Entity;
using Code.Gameplay.StaticData;


namespace Assets.Code.Meta.UI.Shop.Systems
{
    public class ShopItemFactory
    {
        private readonly StaticDataService _staticData;
        private readonly IIdentifierService _identifiers;

        public ShopItemFactory(StaticDataService staticData, IIdentifierService identifiers)
        {
            _staticData = staticData;
            _identifiers = identifiers;
        }

        public MetaEntity CreateShopItem(ShopItemId shopItemId)
        {
            var config = _staticData.GetShopItemConfig(shopItemId);
            switch (config.Kind)
            {
                case Items.ShopItemKind.Booster:
                    return CreateMetaEntity.Empty()
                        .AddId(_identifiers.Next())
                        .AddGoldGainBoost(config.Boost)
                        .AddDuration(config.Duration)
                        ;

                default:
                    throw new System.Exception("Kind not recognized: " + config.Kind);
            }
        }
    }
}
