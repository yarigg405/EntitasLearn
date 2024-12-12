//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPoisonEnchant;

    public static Entitas.IMatcher<GameEntity> PoisonEnchant {
        get {
            if (_matcherPoisonEnchant == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PoisonEnchant);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPoisonEnchant = matcher;
            }

            return _matcherPoisonEnchant;
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

    static readonly Assets.Code.Gameplay.Features.Enchants.PoisonEnchant poisonEnchantComponent = new Assets.Code.Gameplay.Features.Enchants.PoisonEnchant();

    public bool isPoisonEnchant {
        get { return HasComponent(GameComponentsLookup.PoisonEnchant); }
        set {
            if (value != isPoisonEnchant) {
                var index = GameComponentsLookup.PoisonEnchant;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : poisonEnchantComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
