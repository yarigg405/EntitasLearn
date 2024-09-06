using Assets.Code.Gameplay.Cameras.Systems;
using Assets.Code.Gameplay.Features.Hero.Systems;
using Code.Gameplay.Cameras.Provider;


namespace Assets.Code.Gameplay.Features.Hero
{
    internal sealed class HeroFeature : Feature
    {
        public HeroFeature(GameContext context, ICameraProvider cameraProvider)
        {
            Add(new SetHeroDirectionByInputSystem(context));
            Add(new CameraFollowHeroSystem(context, cameraProvider));
        }
    }
}
