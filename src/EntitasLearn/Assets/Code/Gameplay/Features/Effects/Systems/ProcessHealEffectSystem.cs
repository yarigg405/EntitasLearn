using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Effects.Systems
{
    internal sealed class ProcessHealEffectSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _effects;

        internal ProcessHealEffectSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.HealEffect,
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


                if (target.hasMaxHP && target.hasCurrentHP)
                {
                    var newValue = Mathf.Min(target.CurrentHP + effect.EffectValue, target.MaxHP);
                    target.ReplaceCurrentHP(newValue);
                }
            }
        }
    }
}