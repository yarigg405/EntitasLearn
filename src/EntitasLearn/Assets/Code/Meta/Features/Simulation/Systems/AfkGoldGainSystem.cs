using Entitas;


namespace Assets.Code.Meta.Features.Simulation.Systems
{
    internal sealed class AfkGoldGainSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _tick;
        private readonly IGroup<MetaEntity> _storage;

        internal AfkGoldGainSystem(MetaContext meta)
        {
            _tick = meta.GetGroup(MetaMatcher.Tick);
            _storage = meta.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.Storage,
                MetaMatcher.Gold,
                MetaMatcher.GoldPerSecond
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var tick in _tick)
                foreach (var storage in _storage)
                {
                    storage.ReplaceGold(storage.Gold + tick.Tick * storage.GoldPerSecond);
                }
        }
    }
}