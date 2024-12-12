using Assets.Code.Gameplay.Common.Visual.EnchantsVisuals;
using Assets.Code.Infrastructure.View.Registrar;
using UnityEngine;


namespace Assets.Code.Gameplay.Common.Registrars
{
    internal sealed class EnchantVisualsRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private EnchantVisual visual;

        public override void RegisterComponents()
        {
            Entity.AddEnchantVisuals(visual);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasEnchantVisuals)
                Entity.RemoveEnchantVisuals();
        }
    }
}
