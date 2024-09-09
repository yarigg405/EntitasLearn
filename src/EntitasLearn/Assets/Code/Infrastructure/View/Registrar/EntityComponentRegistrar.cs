namespace Assets.Code.Infrastructure.View.Registrar
{
    internal abstract class EntityComponentRegistrar : EntityDependant, IEntityComponentRegistrar
    {
        public abstract void RegisterComponents();
        public abstract void UnregisterComponents(); 
    }
}
