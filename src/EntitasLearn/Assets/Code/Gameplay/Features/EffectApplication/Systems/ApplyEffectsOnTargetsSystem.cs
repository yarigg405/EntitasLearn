using Assets.Code.Gameplay.Features.Effects.Factory;
using Entitas;


namespace Assets.Code.Gameplay.Features.EffectApplication.Systems
{
    internal sealed class ApplyEffectsOnTargetsSystem : IExecuteSystem
    {
        private readonly EffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _entities;
        private readonly GameContext _gameContext;

        public ApplyEffectsOnTargetsSystem(GameContext context, EffectFactory effectFactory)
        {
            _gameContext = context;
            _effectFactory = effectFactory;

            _entities = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.EffectSetups,
                GameMatcher.TargetsBuffer
                ));
        }
        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities)
                foreach (var targetId in entity.TargetsBuffer)
                    foreach (var setup in entity.EffectSetups)
                    {
                        _effectFactory.CreateEffect(setup, ProducerId(entity), targetId);
                    }
        }

        private int ProducerId(GameEntity entity)
        {
            return entity.hasProducerId ? entity.ProducerId : entity.Id;
        }
    }
}
