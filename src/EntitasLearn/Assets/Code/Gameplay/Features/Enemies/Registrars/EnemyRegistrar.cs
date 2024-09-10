using Assets.Code.Infrastructure.View.Registrar;
using Code.Common.Extensions;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Enemies.Registrars
{
    internal sealed class EnemyRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private float speed;

        public override void RegisterComponents()
        {
            Entity
                .AddEnemyTypeId(EnemyTypeId.Goblin)
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(speed)
                .With(x => x.isEnemy = true)
                .With(x=>x.isTurnedAlongDirection = true)
                ;
        }

        public override void UnregisterComponents()
        {
            
        }
    }
}
