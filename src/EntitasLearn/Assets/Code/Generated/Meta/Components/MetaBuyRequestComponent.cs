//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherBuyRequest;

    public static Entitas.IMatcher<MetaEntity> BuyRequest {
        get {
            if (_matcherBuyRequest == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.BuyRequest);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherBuyRequest = matcher;
            }

            return _matcherBuyRequest;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaEntity {

    static readonly Assets.Code.Meta.UI.Shop.BuyRequestComponent buyRequestComponent = new Assets.Code.Meta.UI.Shop.BuyRequestComponent();

    public bool isBuyRequest {
        get { return HasComponent(MetaComponentsLookup.BuyRequest); }
        set {
            if (value != isBuyRequest) {
                var index = MetaComponentsLookup.BuyRequest;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : buyRequestComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
