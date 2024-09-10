//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLayerMask;

    public static Entitas.IMatcher<GameEntity> LayerMask {
        get {
            if (_matcherLayerMask == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LayerMask);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLayerMask = matcher;
            }

            return _matcherLayerMask;
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

    public Assets.Code.Gameplay.Features.TargetCollection.LayerMask layerMask { get { return (Assets.Code.Gameplay.Features.TargetCollection.LayerMask)GetComponent(GameComponentsLookup.LayerMask); } }
    public int LayerMask { get { return layerMask.Value; } }
    public bool hasLayerMask { get { return HasComponent(GameComponentsLookup.LayerMask); } }

    public GameEntity AddLayerMask(int newValue) {
        var index = GameComponentsLookup.LayerMask;
        var component = (Assets.Code.Gameplay.Features.TargetCollection.LayerMask)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.TargetCollection.LayerMask));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceLayerMask(int newValue) {
        var index = GameComponentsLookup.LayerMask;
        var component = (Assets.Code.Gameplay.Features.TargetCollection.LayerMask)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.TargetCollection.LayerMask));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveLayerMask() {
        RemoveComponent(GameComponentsLookup.LayerMask);
        return this;
    }
}
