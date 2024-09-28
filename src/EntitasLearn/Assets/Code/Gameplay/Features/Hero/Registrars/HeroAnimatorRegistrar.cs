using Assets.Code.Infrastructure.View.Registrar;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Hero.Registrars
{
    internal sealed class HeroAnimatorRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private HeroAnimator heroAnimator;

        public override void RegisterComponents()
        {
            Entity
        .AddHeroAnimator(heroAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasHeroAnimator)
                Entity.RemoveHeroAnimator();
        }
    }
}
