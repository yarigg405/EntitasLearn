//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAbilityId;

    public static Entitas.IMatcher<GameEntity> AbilityId {
        get {
            if (_matcherAbilityId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AbilityId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAbilityId = matcher;
            }

            return _matcherAbilityId;
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

    public Assets.Code.Gameplay.Features.Abilities.AbilityComponents.AbilityIdComponent abilityId { get { return (Assets.Code.Gameplay.Features.Abilities.AbilityComponents.AbilityIdComponent)GetComponent(GameComponentsLookup.AbilityId); } }
    public Assets.Code.Gameplay.Features.Abilities.Configs.AbilityId AbilityId { get { return abilityId.Value; } }
    public bool hasAbilityId { get { return HasComponent(GameComponentsLookup.AbilityId); } }

    public GameEntity AddAbilityId(Assets.Code.Gameplay.Features.Abilities.Configs.AbilityId newValue) {
        var index = GameComponentsLookup.AbilityId;
        var component = (Assets.Code.Gameplay.Features.Abilities.AbilityComponents.AbilityIdComponent)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.Abilities.AbilityComponents.AbilityIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAbilityId(Assets.Code.Gameplay.Features.Abilities.Configs.AbilityId newValue) {
        var index = GameComponentsLookup.AbilityId;
        var component = (Assets.Code.Gameplay.Features.Abilities.AbilityComponents.AbilityIdComponent)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.Abilities.AbilityComponents.AbilityIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAbilityId() {
        RemoveComponent(GameComponentsLookup.AbilityId);
        return this;
    }
}
