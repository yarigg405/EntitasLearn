using Entitas;
using System;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Effects.Systems
{
    internal sealed class CleanupProcessedEffects:ICleanupSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(16);

        public CleanupProcessedEffects(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Effect,
                GameMatcher.Processed
                ));
        }

        void ICleanupSystem.Cleanup()
        {
            foreach (var effect in _effects.GetEntities(_buffer))
            {
                effect.Destroy();
            }
        }
    }
}
