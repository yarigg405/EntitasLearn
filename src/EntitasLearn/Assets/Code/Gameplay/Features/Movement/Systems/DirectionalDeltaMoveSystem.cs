using Code.Gameplay.Common.Time;
using Entitas;


namespace Assets.Code.Gameplay.Features.Movement.Systems
{
    internal sealed class DirectionalDeltaMoveSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _movers;

        public DirectionalDeltaMoveSystem(GameContext context, ITimeService timeService)
        {
            _timeService = timeService;
            _movers = context.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Direction,
                    GameMatcher.Speed,
                    GameMatcher.Moving
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _movers)
            {
                var pos = entity.WorldPosition;
                var moveDelta = entity.Direction * entity.Speed * _timeService.DeltaTime;
                pos.x += moveDelta.x;
                pos.z += moveDelta.y;

                entity.ReplaceWorldPosition(pos);
            }
        }
    }
}
