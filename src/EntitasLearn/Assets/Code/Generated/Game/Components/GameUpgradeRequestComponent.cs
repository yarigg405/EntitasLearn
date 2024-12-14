//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherUpgradeRequest;

    public static Entitas.IMatcher<GameEntity> UpgradeRequest {
        get {
            if (_matcherUpgradeRequest == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.UpgradeRequest);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherUpgradeRequest = matcher;
            }

            return _matcherUpgradeRequest;
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

    static readonly Assets.Code.Gameplay.Features.Abilities.AbilityComponents.UpgradeRequest upgradeRequestComponent = new Assets.Code.Gameplay.Features.Abilities.AbilityComponents.UpgradeRequest();

    public bool isUpgradeRequest {
        get { return HasComponent(GameComponentsLookup.UpgradeRequest); }
        set {
            if (value != isUpgradeRequest) {
                var index = GameComponentsLookup.UpgradeRequest;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : upgradeRequestComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
