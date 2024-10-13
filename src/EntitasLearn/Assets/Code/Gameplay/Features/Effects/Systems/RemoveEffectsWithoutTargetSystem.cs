using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Effects.Systems
{
    internal sealed class RemoveEffectsWithoutTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(16);

        internal RemoveEffectsWithoutTargetSystem(GameContext game)
        {
            _effects = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Effect,
                GameMatcher.TargetId
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _effects.GetEntities(_buffer))
            {
                var target = entity.Target();
                if (target == null)
                {
                    entity.Destroy();
                }
            }
        }
    }
}