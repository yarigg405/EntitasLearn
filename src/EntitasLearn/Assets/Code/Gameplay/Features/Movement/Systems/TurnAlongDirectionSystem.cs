using Code.Common.Extensions;
using Entitas;
 using UnityEngine;


namespace Assets.Code.Gameplay.Features.Movement.Systems
{
    internal sealed class TurnAlongDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public TurnAlongDirectionSystem(GameContext context)
        {
            _movers = context.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.TurnedAlongDirection,
                GameMatcher.Transform,
                GameMatcher.Transform));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _movers)
            {
                var scale = Mathf.Abs(entity.Transform.transform.localScale.x);
                entity.Transform.transform.SetScaleX(scale * FaceDirection(entity));
            }
        }

        private float FaceDirection(GameEntity entity)
        {
            if (entity.Direction.x <= 0) return -1;
            return 1;
        }
    }
}
