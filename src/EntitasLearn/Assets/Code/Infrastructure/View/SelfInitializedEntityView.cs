using Assets.Code.Infrastructure.Identifiers;
using Code.Common.Entity;
using UnityEngine;
using Zenject;


namespace Assets.Code.Infrastructure.View
{
    internal sealed class SelfInitializedEntityView : MonoBehaviour
    {
        public EntityBehaviour EntityBehaviour;
        private IEntityView _entityView => EntityBehaviour;


        private IIdentifierService _identifierService;

        [Inject]
        private void Contruct(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        private void Awake()
        {
            var entity = CreateEntity.Empty().AddId(_identifierService.Next());
            _entityView.SetEntity(entity);
        }
    }
}
