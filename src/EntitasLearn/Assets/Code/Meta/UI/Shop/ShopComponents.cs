using Assets.Code.Meta.UI.Shop.Items;
using Assets.Code.Progress;
using Entitas;


namespace Assets.Code.Meta.UI.Shop
{
    [Meta] public class ShopItemIdComponent : ISavedComponent { public ShopItemId Value; }
    [Meta] public class Purchased : ISavedComponent { }
    [Meta] public class BuyRequestComponent : IComponent { }
}
