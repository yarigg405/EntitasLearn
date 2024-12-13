using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Enchants.Systems
{
    internal class RemoveUnappliedEnchantsIconFromHolder : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _holders;
        private readonly IGroup<GameEntity> _enchants;

        public RemoveUnappliedEnchantsIconFromHolder(GameContext game) : base(game)
        {
            _holders = game.GetGroup(GameMatcher.EnchantHolder);

            _enchants = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.EnchantTypeId,
                GameMatcher.TimeLeft
                ));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.AllOf(
                GameMatcher.EnchantTypeId,
                GameMatcher.Unapplied).Added());


        protected override bool Filter(GameEntity entity) => true;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var holder in _holders)
                foreach (var enchant in _enchants)
                {
                    holder.EnchantHolder.RemoveEnchant(enchant.EnchantTypeId);
                }
        }
    }
}
