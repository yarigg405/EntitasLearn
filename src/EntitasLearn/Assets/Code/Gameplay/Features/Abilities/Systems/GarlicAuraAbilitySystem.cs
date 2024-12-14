using Assets.Code.Gameplay.Features.Abilities.Armaments.Factory;
using Assets.Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Upgrade;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Abilities.Systems
{
    internal sealed class GarlicAuraAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(1);
        private readonly ArmamentsFactory _armamentsFactory;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        internal GarlicAuraAbilitySystem(
            GameContext game,
            ArmamentsFactory armamentsFactory,
            IAbilityUpgradeService abilityUpgradeService)
        {
            _armamentsFactory = armamentsFactory;
            _abilityUpgradeService = abilityUpgradeService;
            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Id
                ));

            _abilities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.GarlicAuraAbility
            )
                .NoneOf(GameMatcher.Active)
                );
        }

        void IExecuteSystem.Execute()
        {
            foreach (var ability in _abilities.GetEntities(_buffer))
                foreach (var hero in _heroes)
                {
                    int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.GarlicAura);
                    _armamentsFactory.CreateEffectAura(AbilityId.GarlicAura, hero.Id, level);
                    ability.isActive = true;
                }
        }
    }
}