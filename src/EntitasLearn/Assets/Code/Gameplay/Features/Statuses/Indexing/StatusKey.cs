namespace Assets.Code.Gameplay.Features.Statuses.Indexing
{
    internal struct StatusKey
    {
        public readonly int TargetId;
        public readonly StatusTypeId TypeId;

        public StatusKey(int targetId, StatusTypeId typeId)
        {
            TargetId = targetId;
            TypeId = typeId;
        }
    }
}