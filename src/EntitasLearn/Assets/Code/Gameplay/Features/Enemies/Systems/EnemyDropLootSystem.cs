using Assets.Code.Gameplay.Features.Loot.Factory;
using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Enemies.Systems
{
    internal sealed class EnemyDropLootSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly LootFactory _lootFactory;

        internal EnemyDropLootSystem(GameContext game, LootFactory lootFactory)
        {
            _lootFactory = lootFactory;

            _enemies = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.Transform,
                GameMatcher.ProcessingDeath,
                GameMatcher.Dead
            ));

        }

        void IExecuteSystem.Execute()
        {
            foreach (var enemy in _enemies)
            {
                if (Random.Range(0, 1f) <= 0.15f)
                    _lootFactory.CreateLootItem(Loot.LootTypeId.HealingItem, enemy.Transform.position);
                else if (Random.Range(0, 1f) <= 0.15f)
                    _lootFactory.CreateLootItem(Loot.LootTypeId.PoisonEnchantItem, enemy.Transform.position);
                else if (Random.Range(0, 1f) <= 0.15f)
                    _lootFactory.CreateLootItem(Loot.LootTypeId.ExplosionEnchantItem, enemy.Transform.position);
                else
                    _lootFactory.CreateLootItem(Loot.LootTypeId.ExpGem, enemy.Transform.position);
            }
        }
    }
}