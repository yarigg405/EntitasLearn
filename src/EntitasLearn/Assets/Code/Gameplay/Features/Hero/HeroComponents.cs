using Entitas;


namespace Assets.Code.Gameplay.Features.Hero
{
    [Game] public class Hero : IComponent { }
    [Game] public class HeroAnimatorComponent : IComponent { public HeroAnimator Value; }
}
