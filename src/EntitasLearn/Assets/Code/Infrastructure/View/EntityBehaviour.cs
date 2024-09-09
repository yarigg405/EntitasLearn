using Assets.Code.Gameplay.Common.Collisions;
using Assets.Code.Infrastructure.View.Registrar;
using UnityEngine;
using Zenject;


namespace Assets.Code.Infrastructure.View
{
    internal sealed class EntityBehaviour : MonoBehaviour, IEntityView
    {
        private GameEntity _entity;
        private ICollisionRegistry _collisionRegistry;
        public GameEntity Entity => _entity;


        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        void IEntityView.SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            _entity.Retain(this);

            foreach (var registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
            {
                registrar.RegisterComponents();
            }

            foreach (var collider in GetComponentsInChildren<Collider>(true))
            {
                _collisionRegistry.Register(collider.GetInstanceID(), _entity);
            }
        }

        void IEntityView.ReleaseEntity()
        {
            foreach (var collider in GetComponentsInChildren<Collider>(true))
            {
                _collisionRegistry.Unregister(collider.GetInstanceID());
            }

            foreach (var registrar in GetComponentsInChildren<IEntityComponentRegistrar>())
            {
                registrar.UnregisterComponents();
            }
            _entity.Release(this);
            _entity = null;
        }
    }
}
