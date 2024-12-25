using Code.Gameplay.StaticData;
using Entitas;


namespace Assets.Code.Infrastructure.States.GameStates
{
    internal sealed class CalculateGoldGainSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _boosters;
        private readonly IGroup<MetaEntity> _storages;
        private readonly StaticDataService _staticData;

        internal CalculateGoldGainSystem(MetaContext meta, StaticDataService staticData)
        {
            _boosters = meta.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.GoldGainBoost
            ));

            _storages = meta.GetGroup(MetaMatcher.AllOf(
               MetaMatcher.Storage,
               MetaMatcher.GoldPerSecond
                ));
            _staticData = staticData;
        }

        void IExecuteSystem.Execute()
        {
            foreach (var storage in _storages)
            {
                var gainBonus = 1f;
                foreach (var booster in _boosters)
                    gainBonus += booster.GoldGainBoost;

                storage.ReplaceGoldPerSecond(_staticData.AfkGain.GoldPerSecond * gainBonus);
            }
        }
    }
}