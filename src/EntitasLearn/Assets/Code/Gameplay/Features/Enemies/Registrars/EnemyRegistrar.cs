using Assets.Code.Infrastructure.View.Registrar;
using Code.Common.Extensions;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Enemies.Registrars
{
    internal sealed class EnemyRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Rigidbody rBody;
        [SerializeField] private float hp = 3;
        [SerializeField] private float damage = 5f;
        [SerializeField] private float speed;
        [SerializeField] private float radius = 0.5f;

        public override void RegisterComponents()
        {
            Entity
                .AddEnemyTypeId(EnemyTypeId.Goblin)
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddRigidbody(rBody)
                .AddSpeed(speed)
                .AddDamage(damage)
                .AddCurrentHP(hp)
                .AddMaxHP(hp)
                .AddTargetsBuffer(new(1))
                .AddRadius(radius)
                .AddCollectTargetsInterval(0.5f)
                .AddCollectTargetsTimer(0)
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .With(x => x.isEnemy = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true)
                ;
        }

        public override void UnregisterComponents()
        {

        }
    }
}
