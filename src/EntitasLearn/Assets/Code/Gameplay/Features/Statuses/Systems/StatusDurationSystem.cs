using Code.Gameplay.Common.Time;
using Entitas;


namespace Assets.Code.Gameplay.Features.Statuses.Systems
{
    internal sealed class StatusDurationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly ITimeService _time;

        internal StatusDurationSystem(GameContext game, ITimeService timeService)
        {
            _time = timeService;
            _statuses = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Duration,
                GameMatcher.Status,
                GameMatcher.TimeLeft
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var status in _statuses)
            {
                if (status.TimeLeft >= 0)
                    status.ReplaceTimeLeft(status.TimeLeft - _time.DeltaTime);
                else
                    status.isUnapplied = true;
            }
        }
    }
}