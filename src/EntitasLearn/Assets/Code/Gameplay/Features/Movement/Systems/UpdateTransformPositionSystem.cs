using Code.Gameplay.Common.Time;
using Entitas;
 

namespace Assets.Code.Gameplay.Features.Movement.Systems
{
    internal sealed class UpdateTransformPositionSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _movers;

        public UpdateTransformPositionSystem(GameContext context)
        {
            _movers = context.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.WorldPosition,
                GameMatcher.Transform));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _movers)
            {
                entity.Transform.position = entity.WorldPosition;
            }
        }
    }
}
