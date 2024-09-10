using Entitas;


namespace Assets.Code.Gameplay.Features.Lifetime
{
    internal sealed class DestructOnZeroHpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public DestructOnZeroHpSystem(GameContext context)
        {
            _entities = context.GetGroup(GameMatcher.CurrentHP);
        }
        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities)
            {
                if (entity.CurrentHP <= 0)
                    entity.isDestructed = true;
            }
        }
    }
}
