using Entitas;


namespace Assets.Code.Gameplay.Features.Enemies.Systems
{
    internal sealed class ChaseHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;

        public ChaseHeroSystem(GameContext context)
        {
            _enemies = context.GetGroup(GameMatcher.AllOf(
                  GameMatcher.Enemy,
                  GameMatcher.Transform));

            _heroes = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Transform));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var hero in _heroes)
                foreach (var enemy in _enemies)
                {
                    var direction = (hero.Transform.position - enemy.Transform.position).normalized;
                    enemy.ReplaceDirection(new UnityEngine.Vector2(direction.x, direction.z));
                    enemy.isMoving = true;
                }
        }
    }
}
