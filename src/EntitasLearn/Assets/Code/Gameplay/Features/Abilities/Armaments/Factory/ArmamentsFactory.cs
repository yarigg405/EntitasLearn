using Assets.Code.Infrastructure.Identifiers;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Abilities.Armaments.Factory
{
    internal sealed class ArmamentsFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly StaticDataService _staticDataService;

        public ArmamentsFactory(IIdentifierService identifiers, StaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateVegetableBolt(int level, Vector3 spawnPos)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(Configs.AbilityId.VegerableBolt, level);
            var setup = abilityLevel.ProjectileSetup;

            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddWorldPosition(spawnPos + Vector3.up)
                .With(x => x.isArmament = true)
                .AddViewPrefab(abilityLevel.ViewPrefab)
                .AddSpeed(setup.Speed)
                .AddEffectSetups(abilityLevel.EffectSetups)
                .AddStatusSetups(abilityLevel.StatusSetups)
                .AddRadius(setup.ContactRadius)
                .AddTargetsBuffer(new(16))
                .AddProcessedTargets(new(16))
                .AddTargetLimit(setup.Pierce)
                .AddLayerMask(CollisionLayer.Enemy.AsMask())
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingTargetsContiniously = true)
                .With(x => x.isTurnedAlongDirection = true)
                .AddSelfDestructTimer(setup.Lifetime)
                ;
        }
    }
}
