using System;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Statuses.Indexing
{
    internal sealed class StatusKeyEqualityComparer : IEqualityComparer<StatusKey>
    {
        public bool Equals(StatusKey x, StatusKey y)
        {
            return x.TargetId == y.TargetId && x.TypeId == y.TypeId;
        }

        public int GetHashCode(StatusKey obj)
        {
            return HashCode.Combine(obj.TargetId, obj.TypeId);
        }
    }
}
