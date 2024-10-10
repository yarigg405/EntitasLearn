using Assets.Code.Infrastructure.Identifiers;
using Code.Common.Entity;
using Code.Common.Extensions;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Hero.Factory
{
    internal sealed class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;

        public HeroFactory(IIdentifierService identifiers)
        {
            _identifierService = identifiers;
        }

        public GameEntity CreateHero(Vector3 spawnPos)
        {
            return CreateEntity.Empty()
                  .AddId(_identifierService.Next())
                  .AddWorldPosition(spawnPos)
                  .AddViewPath("Prefabs/Hero")
                  .AddDirection(Vector2.zero)
                  .AddSpeed(2)
                  .AddCurrentHP(100)
                  .AddMaxHP(100)
                  .With(x => x.isHero = true)
                  .With(x => x.isTurnedAlongDirection = true)
                  .With(x => x.isMovementAvailable = true)
                  ;
        }
    }
}
