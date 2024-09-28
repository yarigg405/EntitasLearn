//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHeroAnimator;

    public static Entitas.IMatcher<GameEntity> HeroAnimator {
        get {
            if (_matcherHeroAnimator == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HeroAnimator);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHeroAnimator = matcher;
            }

            return _matcherHeroAnimator;
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

    public Assets.Code.Gameplay.Features.Hero.HeroAnimatorComponent heroAnimator { get { return (Assets.Code.Gameplay.Features.Hero.HeroAnimatorComponent)GetComponent(GameComponentsLookup.HeroAnimator); } }
    public Assets.Code.Gameplay.Features.Hero.HeroAnimator HeroAnimator { get { return heroAnimator.Value; } }
    public bool hasHeroAnimator { get { return HasComponent(GameComponentsLookup.HeroAnimator); } }

    public GameEntity AddHeroAnimator(Assets.Code.Gameplay.Features.Hero.HeroAnimator newValue) {
        var index = GameComponentsLookup.HeroAnimator;
        var component = (Assets.Code.Gameplay.Features.Hero.HeroAnimatorComponent)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.Hero.HeroAnimatorComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceHeroAnimator(Assets.Code.Gameplay.Features.Hero.HeroAnimator newValue) {
        var index = GameComponentsLookup.HeroAnimator;
        var component = (Assets.Code.Gameplay.Features.Hero.HeroAnimatorComponent)CreateComponent(index, typeof(Assets.Code.Gameplay.Features.Hero.HeroAnimatorComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveHeroAnimator() {
        RemoveComponent(GameComponentsLookup.HeroAnimator);
        return this;
    }
}
