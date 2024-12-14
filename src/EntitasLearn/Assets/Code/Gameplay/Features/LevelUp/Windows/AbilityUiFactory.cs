using Assets.Code.Gameplay.Features.LevelUp.Behaviours;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;


namespace Assets.Code.Gameplay.Features.LevelUp.Windows
{
    internal class AbilityUiFactory
    {
        private const string _prefabPath = "UI/Abilities/AbilityCard";
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;

        public AbilityUiFactory(IInstantiator instantiator, IAssetProvider assetProvider)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }

        public AbilityCard CreateAbilityCard(Transform parent)
        {
            return _instantiator
                .InstantiatePrefabForComponent<AbilityCard>(_assetProvider
                .LoadAsset<AbilityCard>(_prefabPath), parent);
        }
    }
}
