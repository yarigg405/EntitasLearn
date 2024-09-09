using Assets.Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.Movement
{
    internal sealed class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systems)
        {
            Add(systems.Create<DirectionalDeltaMoveSystem>());
            Add(systems.Create<TurnAlongDirectionSystem>());
            Add(systems.Create<UpdateTransformPositionSystem>());
        }
    }
}
