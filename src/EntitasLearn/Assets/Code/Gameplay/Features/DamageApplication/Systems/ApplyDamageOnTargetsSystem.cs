using Entitas;


namespace Assets.Code.Gameplay.Features.DamageApplication.Systems
{
    internal sealed class ApplyDamageOnTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly GameContext _gameContext;

        public ApplyDamageOnTargetsSystem(GameContext context)
        {
            _gameContext = context;

            _entities = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.Damage,
                GameMatcher.TargetsBuffer
                ));
        }
        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities)
                foreach (var targetId in entity.TargetsBuffer)
                {
                    var targetEntity = _gameContext.GetEntityWithId(targetId);
                    if (!targetEntity.hasCurrentHP) continue;

                    targetEntity.ReplaceCurrentHP(targetEntity.CurrentHP - entity.Damage);
                }
        }
    }
}
