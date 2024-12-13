using Entitas;


namespace Assets.Code.Gameplay.Features.Loot.Systems
{
    internal sealed class CollectExperienceSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _collected;
        private readonly IGroup<GameEntity> _heroes;

        internal CollectExperienceSystem(GameContext game)
        {
            _collected = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Collected,
                GameMatcher.Experience
            ));

            _heroes = game.GetGroup(GameMatcher.Hero);
        }

        void IExecuteSystem.Execute()
        {
            foreach (var hero in _heroes)
            {
                foreach (var entity in _collected)
                {
                    hero.ReplaceExperience(hero.Experience + entity.Experience);
                }
            }
        }
    }
}