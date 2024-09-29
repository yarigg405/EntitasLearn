using Assets.Code.Gameplay.Features.TargetCollection;
using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Enemies.Systems
{
    internal sealed class EnemyDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;

        public EnemyDeathSystem(GameContext game)
        {
            _enemies = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.Dead,
                GameMatcher.ProcessingDeath));

        }

        void IExecuteSystem.Execute()
        {
            foreach (var enemy in _enemies)
            {
                enemy.isMovementAvailable = false;
                enemy.isTurnedAlongDirection = false;
                enemy.RemoveTargetCollectionComponents();
                enemy.Rigidbody.velocity = Vector3.zero;

                if (enemy.hasEnemyAnimator)
                {
                    enemy.EnemyAnimator.PlayeDeath();                   
                }

                enemy.ReplaceSelfDestructTimer(2);
            }
        }
    }
}
