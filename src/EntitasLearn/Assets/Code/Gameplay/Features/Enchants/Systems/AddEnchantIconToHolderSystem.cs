using Entitas;


namespace Assets.Code.Gameplay.Features.Enchants.Systems
{
    internal sealed class AddEnchantIconToHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _holders;
        private readonly IGroup<GameEntity> _enchants;

        internal AddEnchantIconToHolderSystem(GameContext game)
        {
            _holders = game.GetGroup(GameMatcher.EnchantHolder);

            _enchants = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.EnchantTypeId,
                GameMatcher.TimeLeft
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var holder in _holders)
                foreach (var enchant in _enchants)
                {
                    holder.EnchantHolder.AddEnchant(enchant.EnchantTypeId);
                }
        }
    }
}