namespace Assets.Code.Gameplay.Features.TargetCollection
{
    internal static class TargetCollectionEntityExtensions
    {
        public static GameEntity RemoveTargetCollectionComponents(this GameEntity entity)
        {
            if (entity.hasTargetsBuffer)
                entity.RemoveTargetsBuffer();

            if (entity.hasCollectTargetsInterval)
                entity.RemoveCollectTargetsInterval();

            if (entity.hasCollectTargetsTimer)
                entity.RemoveCollectTargetsTimer();

            entity.isReadyToCollectTargets = false;

            return entity;
        }
    }
}
