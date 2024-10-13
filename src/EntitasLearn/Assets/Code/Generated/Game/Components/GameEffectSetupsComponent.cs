//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEffectSetups;

    public static Entitas.IMatcher<GameEntity> EffectSetups {
        get {
            if (_matcherEffectSetups == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EffectSetups);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEffectSetups = matcher;
            }

            return _matcherEffectSetups;
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

    public Assets.Code.Gameplay.Features.Abilities.Armaments.ArmamentComponents.EffectSetups effectSetups { get { return (Assets.Code.Gameplay.Features.Abilities.Armaments.ArmamentComponents.EffectSetups)GetComponent(GameComponentsLookup.EffectSetups); } }
    public System.Collections.Generic.List<Assets.Code.Gameplay.Features.Effects.EffectSetup> EffectSetups { get { return effectSetups.Value; } }
    public bool hasEffectSetups { get { return HasComponent(GameComponentsLookup.EffectSetups); } }

    public GameEntity AddEffectSetups(System.Collections.Generic.List<Assets.Code.Gameplay.Features.Effects.EffectSetup> newValue) {
        var index = GameComponentsLookup.EffectSetups;
        var component = (Assets.Code.Gameplay.Features.Abilities.Armaments.ArmamentComponents.EffectSetups)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.Abilities.Armaments.ArmamentComponents.EffectSetups));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceEffectSetups(System.Collections.Generic.List<Assets.Code.Gameplay.Features.Effects.EffectSetup> newValue) {
        var index = GameComponentsLookup.EffectSetups;
        var component = (Assets.Code.Gameplay.Features.Abilities.Armaments.ArmamentComponents.EffectSetups)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.Abilities.Armaments.ArmamentComponents.EffectSetups));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveEffectSetups() {
        RemoveComponent(GameComponentsLookup.EffectSetups);
        return this;
    }
}
