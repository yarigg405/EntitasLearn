using Assets.Code.Gameplay.Features.Effects.Factory;
using Code.Gameplay.Common.Time;
using Entitas;


namespace Assets.Code.Gameplay.Features.Statuses.Systems
{
    internal sealed class PeriodicDamageStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly ITimeService _time;
        private readonly EffectFactory _effectFactory;

        internal PeriodicDamageStatusSystem(GameContext game, ITimeService timeService, EffectFactory effectFactory)
        {
            _time = timeService;
            _effectFactory = effectFactory;

            _statuses = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Status,
                GameMatcher.Period,
                GameMatcher.TimeSinceLastTick,
                GameMatcher.EffectValue,
                GameMatcher.ProducerId,
                GameMatcher.TargetId
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var status in _statuses)
            {
                if (status.TimeSinceLastTick >= 0)
                {
                    status.ReplaceTimeSinceLastTick(status.TimeSinceLastTick - _time.DeltaTime);
                }

                else
                {
                    status.ReplaceTimeSinceLastTick(status.Period);
                    _effectFactory.CreateEffect(new Effects.EffectSetup
                    {
                        EffectTypeId = Effects.EffectTypeId.Damage,
                        Value = status.EffectValue,
                    }, status.ProducerId, status.TargetId);
                }
            }
        }
    }
}