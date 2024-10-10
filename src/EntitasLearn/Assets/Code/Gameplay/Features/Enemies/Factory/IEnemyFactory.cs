using UnityEngine;

namespace Assets.Code.Gameplay.Features.Enemies.Factory
{
    internal interface IEnemyFactory
    {
        GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 spawnPos);
    }
}