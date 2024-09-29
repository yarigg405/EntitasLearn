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
                    GameMatcher.MovementAvailable,
                    GameMatcher.Rigidbody
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _movers)
            {
                var moveDelta = entity.Direction * entity.Speed * _timeService.DeltaTime;
                var movingDirection = new Vector3(moveDelta.x, 0, moveDelta.y);
                entity.Rigidbody.velocity = movingDirection * 100;
            }
        }
    }
}
