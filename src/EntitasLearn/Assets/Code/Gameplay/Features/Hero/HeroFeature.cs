using Assets.Code.Gameplay.Cameras.Systems;
using Assets.Code.Gameplay.Features.Hero.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.Hero
{
    internal sealed class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systems)
        {
            Add(systems.Create<SetHeroDirectionByInputSystem>());
            Add(systems.Create<CameraFollowHeroSystem>());
        }
    }
}
