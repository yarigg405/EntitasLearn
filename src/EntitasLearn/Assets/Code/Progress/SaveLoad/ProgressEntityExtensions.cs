using Code.Common.Extensions;
using Entitas;
using System;
using System.Linq;


namespace Assets.Code.Progress.SaveLoad
{
    public static class ProgressEntityExtensions
    {
        public static EntitySnapshot AsSavedEntity(this IEntity entity)
        {
            var components = entity.GetComponents();
            return new EntitySnapshot
            {
                Components = components
                .Where(c => c is ISavedComponent)
                .Cast<ISavedComponent>()
                .ToList()
            };
        }

        public static IEntity HydrateWith(this IEntity entity, EntitySnapshot entityData)
        {
            foreach (var component in entityData.Components)
            {
                int lookupIndex = LookupIndexOf(component, entity);
                entity.With(x => x.ReplaceComponent(lookupIndex, component), when: lookupIndex >= 0);
            }

            return entity;
        }

        private static int LookupIndexOf(ISavedComponent component, IEntity entity)
        {
            return Array.IndexOf(ComponentTypes(entity), component.GetType());
        }

        private static Type[] ComponentTypes(IEntity entity)
        {
            return entity switch
            {
                MetaEntity => MetaComponentsLookup.componentTypes,
                _ => throw new ArgumentException($"Requested lookup for {entity.GetType().Name} is not implemented")
            };

            return MetaComponentsLookup.componentTypes;
        }
    }
}
