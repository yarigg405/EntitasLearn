using Entitas;


namespace Assets.Code.Gameplay.Features.LevelUp.Systems
{
    internal sealed class UpdateExperienceMeterSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _experienceMeters;
        private readonly IGroup<GameEntity> _heroes;

        internal UpdateExperienceMeterSystem(GameContext game)
        {
            _experienceMeters = game.GetGroup(GameMatcher.ExperienceMeter);
            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Experience
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var hero in _heroes)
                foreach (var meter in _experienceMeters)
                {
                    meter.ExperienceMeter.SetExperience(hero.Experience, 100);
                }
        }
    }
}