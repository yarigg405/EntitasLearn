using Assets.Code.Infrastructure.View.Registrar;
using Code.Common.Extensions;
using UnityEngine;


internal sealed class HeroRegistrar : EntityComponentRegistrar
{
    [SerializeField] private float maxHp = 100f;
    [SerializeField] private float speed = 2f;
    private GameEntity _entity;

    public override void RegisterComponents()
    {
        Entity.AddWorldPosition(transform.position)
               .AddDirection(Vector2.zero)
               .AddSpeed(speed)
               .AddCurrentHP(maxHp)
               .AddMaxHP(maxHp)
               .With(x => x.isHero = true)
               .With(x => x.isTurnedAlongDirection = true)
               ;
    }

    public override void UnregisterComponents()
    {

    }
}