using Assets.Code.Gameplay.Features.Abilities.Armaments.Factory;
using Assets.Code.Gameplay.Features.Abilities.Configs;
using Assets.Code.Gameplay.Features.Abilities.Cooldowns;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.StaticData;
using Entitas;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Abilities.Systems
{
    internal sealed class OrbitingMushroomAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;
        private readonly List<GameEntity> _buffer = new(1);

        private readonly StaticDataService _staticDataService;
        private readonly ArmamentsFactory _armamentsFactory;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        internal OrbitingMushroomAbilitySystem(
            GameContext game, 
            StaticDataService staticDataService,
            ArmamentsFactory armamentsFactory,
            IAbilityUpgradeService abilityUpgradeService)
        {
            _staticDataService = staticDataService;
            _armamentsFactory = armamentsFactory;
            _abilityUpgradeService = abilityUpgradeService;
            _abilities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.OrbitingMusrhoomAbility,
                GameMatcher.CooldownIsUp
            ));

            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Transform));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
                foreach (var hero in _heroes)
                {
                    int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.OrbitingMushroom);
                    var abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
                    var projectileCount = abilityLevel.ProjectileSetup.ProjectileCount;

                    for (int i = 0; i < projectileCount; i++)
                    {
                        float phase = (2 * Mathf.PI * i) / projectileCount;
                        CreateProjectile(hero, phase, level);
                    }

                    ability.PutOnCooldown(abilityLevel.CoolDown);
                }
        }

        private void CreateProjectile(GameEntity hero, float phase, int level)
        {
            _armamentsFactory.CreateMushroomBolt(level, hero.Transform.position + Vector3.up, phase)
                .AddProducerId(hero.Id)
                .AddOrbitCenterPosition(hero.Transform.position)
                .AddOrbitCenterFollowTarget(hero.Id)
                .isMoving = true
                ;
        }
    }
}