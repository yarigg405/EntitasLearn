namespace Assets.Code.Infrastructure.View.Factory
{
    internal interface IEntityViewFactory
    {
        EntityBehaviour CreateViewForEntity(GameEntity gameEntity);
        EntityBehaviour CreateViewForEntityFromPrefab(GameEntity gameEntity);
    }
}