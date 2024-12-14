using Code.Gameplay.Features.Abilities.Upgrade;
using Entitas;


namespace Assets.Code.Gameplay.Features.LevelUp.Systems
{
    internal sealed class UpgradeAbilityOnRequestSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _levelups;
        private readonly IGroup<GameEntity> _requests;

        private readonly IAbilityUpgradeService _upgradeService;

        internal UpgradeAbilityOnRequestSystem(GameContext game, IAbilityUpgradeService upgradeService)
        {
            _levelups = game.GetGroup(GameMatcher.LevelUp);

            _requests = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.UpgradeRequest,
                GameMatcher.AbilityId
            ));
            _upgradeService = upgradeService;
        }

        void IExecuteSystem.Execute()
        {
            foreach (var request in _requests)
                foreach (var levelUp in _levelups)
                {
                    _upgradeService.UpgradeAbility(request.AbilityId);

                    levelUp.isProcessed = true;
                    request.isDestructed = true;
                }
        }
    }
}