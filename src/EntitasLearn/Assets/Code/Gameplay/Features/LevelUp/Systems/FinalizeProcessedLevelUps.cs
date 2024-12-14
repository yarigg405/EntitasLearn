using Entitas;


namespace Assets.Code.Gameplay.Features.LevelUp.Systems
{
    internal sealed class FinalizeProcessedLevelUps : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _levelups;

        internal FinalizeProcessedLevelUps(GameContext game)
        {
            _levelups = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.LevelUp,
                GameMatcher.Processed
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var levelUp in _levelups)
            {
                levelUp.isDestructed = true;
            }
        }
    }
}