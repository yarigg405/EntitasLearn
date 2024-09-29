using Assets.Code.Infrastructure.View.Registrar;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Enemies.Registrars
{
    internal sealed class EnemyAnimatorRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private EnemyAnimator enemyAnimator;

        public override void RegisterComponents()
        {
            Entity
        .AddEnemyAnimator(enemyAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasEnemyAnimator)
                Entity.RemoveEnemyAnimator();
        }
    }
}
