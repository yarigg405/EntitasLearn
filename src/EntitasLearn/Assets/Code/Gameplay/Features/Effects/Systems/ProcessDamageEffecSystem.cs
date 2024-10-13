using Entitas;


namespace Assets.Code.Gameplay.Features.Effects.Systems
{
    internal sealed class ProcessDamageEffecSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _effects;

        internal ProcessDamageEffecSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.DamageEffect,
                GameMatcher.EffectValue,
                GameMatcher.TargetId
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var effect in _effects)
            {
                effect.isProcessed = true;

                var target = effect.Target();
                if (target.isDead) continue;

                target.ReplaceCurrentHP(target.CurrentHP - effect.EffectValue);
            }
        }
    }
}