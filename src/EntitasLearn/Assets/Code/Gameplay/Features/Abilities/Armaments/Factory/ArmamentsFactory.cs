using Assets.Code.Gameplay.Features.Abilities.Configs;
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

        private GameEntity CreateProjectileEntity(Vector3 spawnPos, AbilityLevel abilityLevel, ProjectileSetup setup)
        {
            return CreateEntity.Empty()
                  .AddId(_identifiers.Next())
                  .AddWorldPosition(spawnPos + Vector3.up)
                  .With(x => x.isArmament = true)
                  .AddViewPrefab(abilityLevel.ViewPrefab)
                  .AddSpeed(setup.Speed)
                  .With(x => x.AddEffectSetups(abilityLevel.EffectSetups), when: !abilityLevel.EffectSetups.IsNullOrEmpty())
                  .With(x => x.AddStatusSetups(abilityLevel.StatusSetups), when: !abilityLevel.StatusSetups.IsNullOrEmpty())
                  .AddRadius(setup.ContactRadius)
                  .AddTargetsBuffer(new(16))
                  .AddProcessedTargets(new(16))
                  .With(x => x.AddTargetLimit(setup.Pierce), when: setup.Pierce > 0)
                  .AddLayerMask(CollisionLayer.Enemy.AsMask())
                  .With(x => x.isMovementAvailable = true)
                  .With(x => x.isReadyToCollectTargets = true)
                  .With(x => x.isCollectingTargetsContiniously = true)
                  .With(x => x.isTurnedAlongDirection = true)
                  .AddSelfDestructTimer(setup.Lifetime)
                  ;
        }

        public GameEntity CreateVegetableBolt(int level, Vector3 spawnPos)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(Configs.AbilityId.VegerableBolt, level);
            var setup = abilityLevel.ProjectileSetup;

            return CreateProjectileEntity(spawnPos, abilityLevel, setup)
                .AddParentAbility(AbilityId.VegerableBolt)
                ;
        }

        public GameEntity CreateMushroomBolt(int level, Vector3 spawnPos, float phase)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(Configs.AbilityId.OrbitingMushroom, level);
            var setup = abilityLevel.ProjectileSetup;

            return CreateProjectileEntity(spawnPos, abilityLevel, setup)
                .AddParentAbility(AbilityId.OrbitingMushroom)
                .AddOrbitPhase(phase)
                .AddOrbitRadius(setup.OrbitRadius)
                ;
            ;
        }


        public GameEntity CreateEffectAura(AbilityId parentAbilityId, int producerId, int level)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.GarlicAura, level);
            var setup = abilityLevel.AuraSetup;

            return CreateEntity.Empty()
                  .AddId(_identifiers.Next())
                  .AddParentAbility(parentAbilityId)
                  .AddViewPrefab(abilityLevel.ViewPrefab)
                  .AddLayerMask(CollisionLayer.Enemy.AsMask())
                  .AddRadius(setup.Radius)
                  .AddCollectTargetsInterval(setup.Interval)
                  .AddCollectTargetsTimer(0)
                  .With(x => x.AddEffectSetups(abilityLevel.EffectSetups), when: !abilityLevel.EffectSetups.IsNullOrEmpty())
                  .With(x => x.AddStatusSetups(abilityLevel.StatusSetups), when: !abilityLevel.StatusSetups.IsNullOrEmpty())
                  .AddProducerId(producerId)
                  .AddTargetsBuffer(new(16))                  
                  .With(x => x.isFollowingProducer = true)
                  .AddWorldPosition(Vector3.zero)
                  ;
        }
    }
}
