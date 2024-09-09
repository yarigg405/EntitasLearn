using UnityEngine;

namespace Assets.Code.Infrastructure.View
{
    public interface IEntityView
    {
        GameEntity Entity { get; }
        GameObject gameObject { get; }

        void ReleaseEntity();
        void SetEntity(GameEntity entity);
    }
}