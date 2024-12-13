using Assets.Code.Gameplay.Features.Effects.Factory;
using Entitas;


namespace Assets.Code.Gameplay.Features.Loot.Systems
{
    internal sealed class CollectEffectItemSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _collected;
        private readonly IGroup<GameEntity> _heroes;
        private readonly EffectFactory _effectFactory;

        internal CollectEffectItemSystem(GameContext game, EffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
            _collected = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Collected,
                GameMatcher.EffectSetups
            ));

            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Id,
                GameMatcher.Transform
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var hero in _heroes)
                foreach (var collected in _collected)
                    foreach (var effecc in collected.EffectSetups)
                    {
                        _effectFactory.CreateEffect(effecc, hero.Id, hero.Id);
                    }
        }
    }
}