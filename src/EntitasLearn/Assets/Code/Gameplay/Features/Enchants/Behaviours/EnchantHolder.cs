using Assets.Code.Gameplay.Features.Enchants.UiFactories;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace Assets.Code.Gameplay.Features.Enchants.Behaviours
{
    public sealed class EnchantHolder : MonoBehaviour
    {
        [SerializeField] private Transform enchantsContainer;
        private EnchantUiFactory _factory;
        private List<EnchantIcon> _icons = new();


        [Inject]
        private void Construct(EnchantUiFactory factory)
        {
            _factory = factory;
        }


        public void AddEnchant(EnchantTypeId typeId)
        {
            if (_icons.Find(x => x.TypeId == typeId)) return;

            var icon = _factory.CreateIcon(enchantsContainer, typeId);
            _icons.Add(icon);
        }

        public void RemoveEnchant(EnchantTypeId typeId)
        {
            var icon = _icons.Find(x => x.TypeId == typeId);
            if (icon)
            {
                _icons.Remove(icon);
                Destroy(icon.gameObject);                
            }
        }
    }
}
