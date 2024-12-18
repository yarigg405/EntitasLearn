using Code.Progress.Provider;
using Entitas;


namespace Assets.Code.Meta.Features.Simulation.Systems
{
    internal sealed class UpdateSimulationTimeSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _ticks;
        private readonly IProgressProvider _progress;

        internal UpdateSimulationTimeSystem(MetaContext meta, IProgressProvider progress)
        {
            _ticks = meta.GetGroup(MetaMatcher.Tick);
            _progress = progress;
        }

        void IExecuteSystem.Execute()
        {
            foreach (var tick in _ticks)
            {
                _progress.ProgressData.LastSimulationTickTime =
                    _progress.ProgressData.LastSimulationTickTime.AddSeconds(tick.Tick);
            }
        }
    }
}