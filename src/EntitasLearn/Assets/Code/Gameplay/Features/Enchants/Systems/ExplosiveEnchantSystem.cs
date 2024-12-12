using Assets.Code.Gameplay.Features.Abilities.Armaments.Factory;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Enchants.Systems
{
    internal sealed class ExplosiveEnchantSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _enchants;
        private readonly ArmamentsFactory _armamentsFactory;

        public ExplosiveEnchantSystem(GameContext game, ArmamentsFactory armamentsFactory) : base(game)
        {
            _armamentsFactory = armamentsFactory;

            _enchants = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.EnchantTypeId,
                GameMatcher.ProducerId,
                GameMatcher.ExplosiveEnchant
            ));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.AllOf(
                GameMatcher.Armament,
                GameMatcher.Reached)
                .Added());

        protected override bool Filter(GameEntity entity) =>
            entity.isArmament && entity.hasTransform;


        protected override void Execute(List<GameEntity> armaments)
        {
            foreach (var enchant in _enchants)
                foreach (var armament in armaments)
                {
                    _armamentsFactory.CreateExplosion(enchant.ProducerId, armament.Transform.position);
                }
        }
    }
}
