using Assets.Code.Gameplay.Features.Movement.Systems;
using Code.Gameplay.Common.Time;


namespace Assets.Code.Gameplay.Features.Movement
{
    internal sealed class MovementFeature : Feature
    {
        public MovementFeature(GameContext context, ITimeService timeService)
        {
            Add(new DirectionalDeltaMoveSystem(context, timeService));
            Add(new TurnAlongDirectionSystem(context));
            Add(new UpdateTransformPositionSystem(context));
        }
    }
}
