using Entitas;


namespace Assets.Code.Gameplay.Features.Abilities.Systems
{
    internal sealed class DestroyAbilityEntitiesOnUpgradeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _upgradeRequests;
        private readonly GameContext _game;

        internal DestroyAbilityEntitiesOnUpgradeSystem(GameContext game)
        {
            _abilities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.AbilityId,
                GameMatcher.RecreatedOnUpgrade
                ));

            _upgradeRequests = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.UpgradeRequest,
                GameMatcher.AbilityId
            ));
            _game = game;
        }

        void IExecuteSystem.Execute()
        {
            foreach (var request in _upgradeRequests)
                foreach (var ability in _abilities)
                {
                    if (request.AbilityId == ability.AbilityId)
                    {
                      foreach(var child in  _game.GetEntitiesWithParentAbility(ability.AbilityId))
                            child.isDestructed = true;

                        ability.isActive = false;
                    }
                }
        }
    }
}