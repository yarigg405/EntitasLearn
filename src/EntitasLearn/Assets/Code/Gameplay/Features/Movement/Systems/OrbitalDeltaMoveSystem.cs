using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Movement.Systems
{
    internal sealed class OrbitalDeltaMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;
        private readonly ITimeService _time;

        internal OrbitalDeltaMoveSystem(GameContext game, ITimeService timeService)
        {
            _time = timeService;
            _movers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.OrbitPhase,
                GameMatcher.OrbitCenterPosition,
                GameMatcher.OrbitRadius,
                GameMatcher.Speed,
                GameMatcher.MovementAvailable,
                GameMatcher.Moving
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var mover in _movers)
            {
                var phase = mover.OrbitPhase + _time.DeltaTime * mover.Speed;
                mover.ReplaceOrbitPhase(phase);

                var newRelativePosition = new Vector3(
                    Mathf.Cos(phase) * mover.OrbitRadius,
                    0,
                    Mathf.Sin(phase) * mover.OrbitRadius
                    );

                var newPosition = newRelativePosition + mover.OrbitCenterPosition;
                mover.ReplaceWorldPosition(newPosition);
                mover.Transform.position = newPosition;
            }
        }
    }
}