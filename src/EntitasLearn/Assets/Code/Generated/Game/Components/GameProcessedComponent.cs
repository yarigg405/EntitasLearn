//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherProcessed;

    public static Entitas.IMatcher<GameEntity> Processed {
        get {
            if (_matcherProcessed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Processed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherProcessed = matcher;
            }

            return _matcherProcessed;
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

    static readonly Assets.Code.Gameplay.Features.Abilities.Armaments.ArmamentComponents.Processed processedComponent = new Assets.Code.Gameplay.Features.Abilities.Armaments.ArmamentComponents.Processed();

    public bool isProcessed {
        get { return HasComponent(GameComponentsLookup.Processed); }
        set {
            if (value != isProcessed) {
                var index = GameComponentsLookup.Processed;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : processedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
