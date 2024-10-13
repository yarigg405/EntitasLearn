using Assets.Code.Gameplay.Features.Effects;
using Assets.Code.Infrastructure.Identifiers;
using Code.Common.Entity;
using Code.Common.Extensions;
using System;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Enemies.Factory
{
    internal sealed class EnemyFactory : IEnemyFactory
    {
        private readonly IIdentifierService _identifierService;

        public EnemyFactory(IIdentifierService identifiers)
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
                 .AddEffectSetups(new System.Collections.Generic.List<EffectSetup>() { new EffectSetup { EffectTypeId = EffectTypeId.Damage, Value = 5 } })
                 .AddCurrentHP(3)
                 .AddMaxHP(3)
                 .AddTargetsBuffer(new(1))
                 .AddRadius(1)
                 .AddCollectTargetsInterval(0.5f)
                 .AddCollectTargetsTimer(0)
                 .AddLayerMask(CollisionLayer.Hero.AsMask())
                 .AddViewPath("Prefabs/Goblin")
                 .With(x => x.isEnemy = true)
                 .With(x => x.isTurnedAlongDirection = true)
                 .With(x => x.isMovementAvailable = true)
                 ;
        }

    }
}
