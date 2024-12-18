using Entitas;


namespace Assets.Code.Meta.Features.Simulation.Systems
{
    internal sealed class BoosterDurationSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _boosters;
        private readonly IGroup<MetaEntity> _ticks;

        internal BoosterDurationSystem(MetaContext meta)
        {
            _ticks = meta.GetGroup(MetaMatcher.Tick);

            _boosters = meta.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.GoldGainBoost,
                MetaMatcher.Duration
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var tick in _ticks)
                foreach (var booster in _boosters)
                {
                    booster.ReplaceDuration(booster.Duration - tick.Tick);

                    if (booster.Duration <= 0)
                        booster.isDestructed = true;
                }
        }
    }
}