//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherGold;

    public static Entitas.IMatcher<MetaEntity> Gold {
        get {
            if (_matcherGold == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.Gold);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherGold = matcher;
            }

            return _matcherGold;
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

    public Assets.Code.Meta.Features.Storage.Gold gold { get { return (Assets.Code.Meta.Features.Storage.Gold)GetComponent(MetaComponentsLookup.Gold); } }
    public float Gold { get { return gold.Value; } }
    public bool hasGold { get { return HasComponent(MetaComponentsLookup.Gold); } }

    public MetaEntity AddGold(float newValue) {
        var index = MetaComponentsLookup.Gold;
        var component = (Assets.Code.Meta.Features.Storage.Gold)CreateComponent(index, typeof(Assets.Code.Meta.Features.Storage.Gold));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public MetaEntity ReplaceGold(float newValue) {
        var index = MetaComponentsLookup.Gold;
        var component = (Assets.Code.Meta.Features.Storage.Gold)CreateComponent(index, typeof(Assets.Code.Meta.Features.Storage.Gold));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public MetaEntity RemoveGold() {
        RemoveComponent(MetaComponentsLookup.Gold);
        return this;
    }
}
