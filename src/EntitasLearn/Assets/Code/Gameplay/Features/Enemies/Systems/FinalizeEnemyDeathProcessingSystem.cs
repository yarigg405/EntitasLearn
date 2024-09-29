using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Enemies.Systems
{
    internal sealed class FinalizeEnemyDeathProcessingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly List<GameEntity> _buffer = new(128);

        public FinalizeEnemyDeathProcessingSystem(GameContext game)
        {
            _enemies = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.Dead,
                GameMatcher.ProcessingDeath
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var enemy in _enemies.GetEntities(_buffer))
            {
                enemy.isProcessingDeath = false;
            }
        }
    }
}
