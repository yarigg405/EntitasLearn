using Assets.Code.Gameplay.Common.Visual.StatusVisuals;
using Assets.Code.Infrastructure.View.Registrar;
using UnityEngine;


namespace Assets.Code.Gameplay.Common.Registrars
{
    internal sealed class StatusVisualsRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private StatusVisuals statusVisuals;

        public override void RegisterComponents()
        {
            Entity.AddStatusVisuals(statusVisuals);
        }

        public override void UnregisterComponents()
        {
            Entity.RemoveStatusVisuals();
        }
    }
}
