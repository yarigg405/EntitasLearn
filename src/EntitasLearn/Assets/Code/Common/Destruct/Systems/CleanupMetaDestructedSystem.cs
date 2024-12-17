using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Common.Destruct.Systems
{
    internal sealed class CleanupMetaDestructedSystem : ICleanupSystem
    {
        private readonly IGroup<MetaEntity> _entities;
        private readonly List<MetaEntity> _buffer = new(16);

        public CleanupMetaDestructedSystem(MetaContext context)
        {
            _entities = context.GetGroup(MetaMatcher.Destructed);
        }

        void ICleanupSystem.Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity.Destroy();
            }
        }
    }
}
