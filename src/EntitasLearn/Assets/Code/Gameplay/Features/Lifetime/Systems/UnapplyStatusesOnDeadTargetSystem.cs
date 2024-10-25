using Entitas;


namespace Assets.Code.Gameplay.Features.Lifetime.Systems
{
    internal sealed class UnapplyStatusesOnDeadTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _dead;

        internal UnapplyStatusesOnDeadTargetSystem(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Status,
                GameMatcher.TargetId
            ));

            _dead = game.GetGroup(GameMatcher.AllOf(
                 GameMatcher.Id,
                 GameMatcher.Dead
             ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var dead in _dead)
                foreach (var status in _statuses)
                {
                    if (status.TargetId == dead.Id)
                        status.isUnapplied = true;
                }
        }
    }
}