//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCooldownLeft;

    public static Entitas.IMatcher<GameEntity> CooldownLeft {
        get {
            if (_matcherCooldownLeft == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CooldownLeft);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCooldownLeft = matcher;
            }

            return _matcherCooldownLeft;
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

    public Assets.Code.Gameplay.Features.Abilities.Cooldowns.CooldownComponents.CooldownLeft cooldownLeft { get { return (Assets.Code.Gameplay.Features.Abilities.Cooldowns.CooldownComponents.CooldownLeft)GetComponent(GameComponentsLookup.CooldownLeft); } }
    public float CooldownLeft { get { return cooldownLeft.Value; } }
    public bool hasCooldownLeft { get { return HasComponent(GameComponentsLookup.CooldownLeft); } }

    public GameEntity AddCooldownLeft(float newValue) {
        var index = GameComponentsLookup.CooldownLeft;
        var component = (Assets.Code.Gameplay.Features.Abilities.Cooldowns.CooldownComponents.CooldownLeft)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.Abilities.Cooldowns.CooldownComponents.CooldownLeft));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCooldownLeft(float newValue) {
        var index = GameComponentsLookup.CooldownLeft;
        var component = (Assets.Code.Gameplay.Features.Abilities.Cooldowns.CooldownComponents.CooldownLeft)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.Abilities.Cooldowns.CooldownComponents.CooldownLeft));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCooldownLeft() {
        RemoveComponent(GameComponentsLookup.CooldownLeft);
        return this;
    }
}
