using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;


namespace Assets.Code.Infrastructure.View.Factory
{
    internal sealed class EntityViewFactory : IEntityViewFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public EntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }

        public EntityBehaviour CreateViewForEntity(GameEntity gameEntity)
        {
            var prefab = _assetProvider.LoadAsset<EntityBehaviour>(gameEntity.ViewPath);
            var view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                prefab,
                position: gameEntity.WorldPosition,
                Quaternion.identity,
                parentTransform: null);

            view.SetEntity(gameEntity);
            return view;
        }

        public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity gameEntity)
        {
            var view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                gameEntity.ViewPrefab,
                position: gameEntity.WorldPosition,
                Quaternion.identity,
                parentTransform: null);

            view.SetEntity(gameEntity);
            return view;
        }
    }
}
