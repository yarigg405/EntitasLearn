using Assets.Code.Gameplay.Common;
using Assets.Code.Gameplay.Features.Enemies.Factory;
using Code.Common.Entity;
using Code.Gameplay.Common.Time;
using Entitas;
using Yrr.Utils;


namespace Assets.Code.Gameplay.Features.Enemies.Systems
{
    internal sealed class EnemySpawnSystem : IExecuteSystem, IInitializeSystem
    {
        private readonly IGroup<GameEntity> _timers;
        private readonly IGroup<GameEntity> _heroes;
        private readonly ITimeService _time;
        private readonly IEnemyFactory _enemyFactory;

        public EnemySpawnSystem(GameContext game, ITimeService timeService, IEnemyFactory enemyFactory)
        {
            _time = timeService;
            _enemyFactory = enemyFactory;

            _timers = game.GetGroup(GameMatcher.SpawnTimer);
            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Transform));
        }

        void IInitializeSystem.Initialize()
        {
            CreateEntity.Empty().AddSpawnTimer(GameplayConstants.EnemySpawnTimer);
        }

        void IExecuteSystem.Execute()
        {
            foreach (var hero in _heroes)
                foreach (var timer in _timers)
                {
                    timer.ReplaceSpawnTimer(timer.SpawnTimer - _time.DeltaTime);
                    if (timer.SpawnTimer <= 0)
                    {
                        timer.ReplaceSpawnTimer(1);
                        _enemyFactory.CreateEnemy(EnemyTypeId.Goblin, hero.Transform.position.GetRandomCoordinatesAroundPointZX(20f, true));
                    }
                }
        }
    }
}
