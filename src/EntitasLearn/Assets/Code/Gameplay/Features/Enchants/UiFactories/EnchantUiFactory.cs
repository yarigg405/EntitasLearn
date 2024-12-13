using Assets.Code.Gameplay.Features.Enchants.Behaviours;
using Code.Gameplay.StaticData;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;


namespace Assets.Code.Gameplay.Features.Enchants.UiFactories
{
    internal class EnchantUiFactory
    {
        private const string _enchantPrefabPath = "UI/Enchants/enchantIcon";
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assetProvider;
        private readonly StaticDataService _staticData;

        public EnchantUiFactory(IInstantiator instantiator, IAssetProvider assetProvider, StaticDataService staticData)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
            _staticData = staticData;
        }

        public EnchantIcon CreateIcon(Transform parent, EnchantTypeId id)
        {
            var config = _staticData.GetEnchantConfig(id);
            EnchantIcon icon = _instantiator.InstantiatePrefabForComponent<EnchantIcon>(_assetProvider.LoadAsset<EnchantIcon>(_enchantPrefabPath));
            icon.transform.SetParent(parent);
            icon.Set(config);

            return icon;
        }
    }
}
