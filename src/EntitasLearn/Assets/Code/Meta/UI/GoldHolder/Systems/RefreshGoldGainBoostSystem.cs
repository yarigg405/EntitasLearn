using Assets.Code.Meta.UI.GoldHolder.Service;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Meta.UI.GoldHolder.Systems
{
    internal class RefreshGoldGainBoostSystem : ReactiveSystem<MetaEntity>, IInitializeSystem
    {
        private readonly StorageUIService _storage;
        private readonly IGroup<MetaEntity> _boosters;
        private readonly List<MetaEntity> _boostersBuffer = new(4);

        public RefreshGoldGainBoostSystem(MetaContext meta, StorageUIService storage) : base(meta)
        {
            _storage = storage;
            _boosters = meta.GetGroup(MetaMatcher.GoldGainBoost);
        }

        protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
        {
            return
            context.CreateCollector(MetaMatcher.GoldGainBoost.AddedOrRemoved());
        }

        protected override bool Filter(MetaEntity entity)
        {
            return true;
        }

        protected override void Execute(List<MetaEntity> boosters)
        {
            UpdateGoldGain(boosters);
        }

        private void UpdateGoldGain(List<MetaEntity> boosters)
        {
            float goldGainBoost = 0;
            foreach (var booster in boosters)
            {
                if (booster.hasGoldGainBoost)
                    goldGainBoost += booster.GoldGainBoost;
            }

            _storage.GoldGainBoost.Value = goldGainBoost;
        }

        void IInitializeSystem.Initialize()
        {
            UpdateGoldGain(_boosters.GetEntities(_boostersBuffer));
        }
    }
}

