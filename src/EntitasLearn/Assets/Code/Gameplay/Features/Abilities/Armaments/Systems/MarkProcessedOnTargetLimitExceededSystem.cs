using Entitas;


namespace Assets.Code.Gameplay.Features.Abilities.Armaments.Systems
{
    internal sealed class MarkProcessedOnTargetLimitExceededSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;

        internal MarkProcessedOnTargetLimitExceededSystem(GameContext game)
        {
            _armaments = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Armament,
                GameMatcher.TargetLimit,
                GameMatcher.ProcessedTargets
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _armaments)
            {
                if (entity.ProcessedTargets.Count >= entity.TargetLimit)
                    entity.isProcessed = true;
            }
        }
    }
}