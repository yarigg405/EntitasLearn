using Assets.Code.Gameplay.Features.Enchants.Behaviours;
using Assets.Code.Infrastructure.View.Registrar;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Enchants.Registrars
{
    internal class EnchantHolderRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private EnchantHolder holder;

        public override void RegisterComponents()
        {
            Entity.AddEnchantHolder(holder);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasEnchantHolder)
                Entity.RemoveEnchantHolder();
        }
    }
}
