using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;


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
                var pos = ((Vector2)entity.WorldPosition) + entity.Direction * entity.Speed * _timeService.DeltaTime;
                entity.ReplaceWorldPosition(pos);
            }
        }
    }
}
