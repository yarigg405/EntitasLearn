using Assets.Code.Meta.UI.GoldHolder.Service;
using Entitas;


namespace Assets.Code.Meta.UI.GoldHolder.Systems
{
    internal sealed class RefreshGoldSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _storages;
        private readonly StorageUIService _storageUIService;

        internal RefreshGoldSystem(MetaContext meta, StorageUIService storage)
        {
            _storageUIService = storage;

            _storages = meta.GetGroup(MetaMatcher.AllOf(
                MetaMatcher.Storage,
                MetaMatcher.Gold
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var storage in _storages)
            {
                _storageUIService.CurrentGold.Value = storage.Gold;
            }
        }
    }
}