using Assets.Code.Gameplay.Features.LevelUp.Services;
using Entitas;


namespace Assets.Code.Gameplay.Features.Loot.Systems
{
    internal sealed class CollectExperienceSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _collected;
        private readonly IGroup<GameEntity> _heroes;
        private readonly LevelUpService _levelUpService;

        internal CollectExperienceSystem(GameContext game, LevelUpService levelUpService)
        {
            _collected = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Collected,
                GameMatcher.Experience
            ));

            _heroes = game.GetGroup(GameMatcher.Hero);
            _levelUpService = levelUpService;
        }

        void IExecuteSystem.Execute()
        {
            foreach (var hero in _heroes)
            {
                foreach (var entity in _collected)
                {
                    _levelUpService.AddExperience(entity.Experience);
                    hero.ReplaceExperience(_levelUpService.CurrentExperience);
                }
            }
        }
    }
}