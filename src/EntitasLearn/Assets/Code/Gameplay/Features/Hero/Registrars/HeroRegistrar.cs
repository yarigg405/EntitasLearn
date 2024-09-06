using Code.Common.Entity;
using Code.Common.Extensions;
using UnityEngine;


internal sealed class HeroRegistrar : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private GameEntity _entity;

    private void Awake()
    {
        _entity = CreateEntity
            .Empty()
            .AddTransform(transform)
            .AddWorldPosition(transform.position)
            .AddDirection(Vector2.zero)
            .AddSpeed(speed)
            .With(x => x.isHero = true)
            .With(x => x.isTurnedAlongDirection = true)
            ;
    }

}