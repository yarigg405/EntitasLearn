using Assets.Code.Gameplay.Features.CharacterStats;
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
            var baseStats = InitStats.EmptyStatDictionary()
                .With(x => x[Stats.Speed] = 2f)
                .With(x => x[Stats.MaxHp] = 5f);


            return CreateEntity.Empty()
                  .AddId(_identifierService.Next())
                  .AddWorldPosition(spawnPos)
                  .AddBaseStats(baseStats)
                  .AddStatModifiers(InitStats.EmptyStatDictionary())
                  .AddViewPath("Prefabs/Hero")
                  .AddDirection(Vector2.zero)
                  .AddSpeed(baseStats[Stats.Speed])
                  .AddCurrentHP(baseStats[Stats.MaxHp])
                  .AddMaxHP(baseStats[Stats.MaxHp])
                  .AddExperience(0)
                  .AddPickupRadius(1)
                  .With(x => x.isHero = true)
                  .With(x => x.isTurnedAlongDirection = true)
                  .With(x => x.isMovementAvailable = true)
                  ;
        }
    }
}
