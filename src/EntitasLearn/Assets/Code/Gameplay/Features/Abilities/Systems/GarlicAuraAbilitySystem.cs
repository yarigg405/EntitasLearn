using Assets.Code.Gameplay.Features.Abilities.Armaments.Factory;
using Assets.Code.Gameplay.Features.Abilities.Configs;
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

        internal GarlicAuraAbilitySystem(GameContext game, ArmamentsFactory armamentsFactory)
        {
            _armamentsFactory = armamentsFactory;
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
                    _armamentsFactory.CreateEffectAura(AbilityId.GarlicAura, hero.Id, 1);
                    ability.isActive = true;
                }
        }
    }
}