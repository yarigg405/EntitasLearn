//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEnchantTypeId;

    public static Entitas.IMatcher<GameEntity> EnchantTypeId {
        get {
            if (_matcherEnchantTypeId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EnchantTypeId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEnchantTypeId = matcher;
            }

            return _matcherEnchantTypeId;
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
public partial class GameEntity {

    public Assets.Code.Gameplay.Features.Enchants.EnchantTypeIdComponent enchantTypeId { get { return (Assets.Code.Gameplay.Features.Enchants.EnchantTypeIdComponent)GetComponent(GameComponentsLookup.EnchantTypeId); } }
    public Assets.Code.Gameplay.Features.Enchants.EnchantTypeId EnchantTypeId { get { return enchantTypeId.Value; } }
    public bool hasEnchantTypeId { get { return HasComponent(GameComponentsLookup.EnchantTypeId); } }

    public GameEntity AddEnchantTypeId(Assets.Code.Gameplay.Features.Enchants.EnchantTypeId newValue) {
        var index = GameComponentsLookup.EnchantTypeId;
        var component = (Assets.Code.Gameplay.Features.Enchants.EnchantTypeIdComponent)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.Enchants.EnchantTypeIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceEnchantTypeId(Assets.Code.Gameplay.Features.Enchants.EnchantTypeId newValue) {
        var index = GameComponentsLookup.EnchantTypeId;
        var component = (Assets.Code.Gameplay.Features.Enchants.EnchantTypeIdComponent)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.Enchants.EnchantTypeIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveEnchantTypeId() {
        RemoveComponent(GameComponentsLookup.EnchantTypeId);
        return this;
    }
}
