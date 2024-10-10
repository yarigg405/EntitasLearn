using Assets.Code.Infrastructure.Identifiers;
using Code.Common.Entity;
using Code.Common.Extensions;
using System;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Enemies.Factory
{
    internal sealed class EnemyFactory : IEnemyFactory
    {
        private readonly IdentifierService _identifierService;

        public EnemyFactory(IdentifierService identifiers)
        {
            _identifierService = identifiers;
        }

        public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 spawnPos)
        {
            switch (typeId)
            {
                case EnemyTypeId.Goblin:
                    return CreateGoblin(spawnPos);
            }

            throw new NotImplementedException();
        }


        private GameEntity CreateGoblin(Vector3 spawnPos)
        {
            return CreateEntity.Empty()
                 .AddId(_identifierService.Next())
                 .AddEnemyTypeId(EnemyTypeId.Goblin)
                 .AddWorldPosition(spawnPos)
                 .AddDirection(Vector2.zero)
                 .AddSpeed(1.5f)
                 .AddDamage(5)
                 .AddCurrentHP(3)
                 .AddMaxHP(3)
                 .AddTargetsBuffer(new(1))
                 .AddRadius(1)
                 .AddCollectTargetsInterval(0.5f)
                 .AddCollectTargetsTimer(0)
                 .AddLayerMask(CollisionLayer.Hero.AsMask())
                 .With(x => x.isEnemy = true)
                 .With(x => x.isTurnedAlongDirection = true)
                 .With(x => x.isMovementAvailable = true)
                 ;
        }

    }
}
