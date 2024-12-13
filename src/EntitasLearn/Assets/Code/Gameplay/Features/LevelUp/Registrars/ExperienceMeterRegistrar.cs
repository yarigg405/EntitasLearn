using Assets.Code.Gameplay.Features.LevelUp.Behaviours;
using Assets.Code.Infrastructure.View.Registrar;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.LevelUp.Registrars
{
    internal class ExperienceMeterRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private ExperienceMeter experienceMeter;
        public override void RegisterComponents()
        {
            Entity.AddExperienceMeter(experienceMeter);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasExperienceMeter)
                Entity.RemoveExperienceMeter();
        }
    }
}
