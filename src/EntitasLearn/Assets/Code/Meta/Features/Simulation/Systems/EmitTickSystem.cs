using Code.Common.Entity;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Systems;


namespace Assets.Code.Meta.Features.Simulation.Systems
{
    public class EmitTickSystem : TimerExecuteSystem
    {
        private readonly float _interval;

        public EmitTickSystem(float executeIntervalSeconds, ITimeService time) : base(executeIntervalSeconds, time)
        {
            _interval = executeIntervalSeconds;
        }

        protected override void Execute()
        {
            CreateMetaEntity.Empty()
                .AddTick(_interval);
        }
    }
}