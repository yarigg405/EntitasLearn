using Assets.Code.Gameplay.Features.Abilities.Armaments.Factory;
using Assets.Code.Gameplay.Features.Abilities.Configs;
using Assets.Code.Gameplay.Features.Abilities.Cooldowns;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Entitas;
using System.Collections.Generic;
using Yrr.Utils;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Abilities.Systems
{
    internal sealed class VegetableBoltAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;
        private readonly List<GameEntity> _buffer = new(1);

        private readonly StaticDataService _staticDataService;
        private readonly ArmamentsFactory _armamentsFactory;

        internal VegetableBoltAbilitySystem(GameContext game, StaticDataService staticDataService, ArmamentsFactory armamentsFactory)
        {
            _staticDataService = staticDataService;
            _armamentsFactory = armamentsFactory;

            _abilities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.VegetableBoltAbitily,
                GameMatcher.CooldownIsUp
            ));

            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Transform));

            _enemies = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.Transform));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var hero in _heroes)
                foreach (var ability in _abilities.GetEntities(_buffer))
                {
                    if (_enemies.count < 1)
                        continue;

                    _armamentsFactory
                        .CreateVegetableBolt(1, hero.Transform.position)
                        .AddProducerId(hero.Id)
                        .ReplaceDirection(RandomEnemyDirection(hero.Transform))
                        .With(x => x.isMoving = true);

                    ability.PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.VegerableBolt, 1).CoolDown);
                }
        }

        private Vector2 RandomEnemyDirection(Transform hero)
        {
            var enemy = _enemies.AsEnumerable().GetRandomItem();
            var delta = (enemy.Transform.position - hero.position).normalized;
            return new Vector2(delta.x, delta.z);
        }
    }
}