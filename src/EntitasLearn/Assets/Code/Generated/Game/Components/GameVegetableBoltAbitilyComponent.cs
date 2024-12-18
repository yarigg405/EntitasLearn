//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherVegetableBoltAbitily;

    public static Entitas.IMatcher<GameEntity> VegetableBoltAbitily {
        get {
            if (_matcherVegetableBoltAbitily == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VegetableBoltAbitily);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVegetableBoltAbitily = matcher;
            }

            return _matcherVegetableBoltAbitily;
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

    static readonly Assets.Code.Gameplay.Features.Abilities.AbilityComponents.VegetableBoltAbitily vegetableBoltAbitilyComponent = new Assets.Code.Gameplay.Features.Abilities.AbilityComponents.VegetableBoltAbitily();

    public bool isVegetableBoltAbitily {
        get { return HasComponent(GameComponentsLookup.VegetableBoltAbitily); }
        set {
            if (value != isVegetableBoltAbitily) {
                var index = GameComponentsLookup.VegetableBoltAbitily;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : vegetableBoltAbitilyComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
