using Assets.Code.Gameplay.Cameras.Systems;
using Assets.Code.Gameplay.Features.Hero.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.Hero
{
    internal sealed class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeHeroSystem>());

            Add(systems.Create<SetHeroDirectionByInputSystem>());
            Add(systems.Create<CameraFollowHeroSystem>());
            Add(systems.Create<AnimateHeroMovementSystem>());
            Add(systems.Create<HeroDeathSystem>());

            Add(systems.Create<FinalizeHeroDeathProcessingSystem>());
        }
    }
}
