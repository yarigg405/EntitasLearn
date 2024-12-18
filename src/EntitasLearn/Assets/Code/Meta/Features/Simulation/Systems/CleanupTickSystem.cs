using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Meta.Features.Simulation.Systems
{
    internal sealed class CleanupTickSystem : ICleanupSystem
    {
        private readonly IGroup<MetaEntity> _ticks;
        private readonly List<MetaEntity> _buffer = new(1);

        internal CleanupTickSystem(MetaContext game)
        {
            _ticks = game.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.Tick
            ));
        }

        void ICleanupSystem.Cleanup()
        {
            foreach (var tick in _ticks.GetEntities(_buffer))
            {
                tick.Destroy();
            }
        }
    }
}