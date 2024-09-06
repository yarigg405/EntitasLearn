using Assets.Code.Gameplay.Features.Hero;
using Assets.Code.Gameplay.Features.Movement;
using Assets.Code.Gameplay.Input;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Input.Service;


namespace Assets.Code.Gameplay
{
    internal sealed class BattleFeature : Feature
    {
        public BattleFeature(GameContext gameContext, ITimeService timeService, IInputService inputService,ICameraProvider camera)
        {
            Add(new InputFeature(gameContext, inputService));
            Add(new MovementFeature(gameContext, timeService));
            Add(new HeroFeature(gameContext,camera));
        }
    }
}
