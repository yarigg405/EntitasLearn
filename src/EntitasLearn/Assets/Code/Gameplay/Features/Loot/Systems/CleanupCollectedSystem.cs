using Entitas;


namespace Assets.Code.Gameplay.Features.Loot.Systems
{
    internal class CleanupCollectedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _collected;


        public CleanupCollectedSystem(GameContext game)
        {
            _collected = game.GetGroup(GameMatcher.Collected);
        }

        void ICleanupSystem.Cleanup()
        {
            foreach (var entity in _collected)
            {
                entity.isDestructed = true;
            }
        }
    }
}
