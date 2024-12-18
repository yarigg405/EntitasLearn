using Assets.Code.Progress.SaveLoad;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Systems;


namespace Assets.Code.Progress.Systems
{
    public class PeriodicallySaveProgressSystem : TimerExecuteSystem
    {
        private readonly ISaveLoadService _saveLoadService;

        public PeriodicallySaveProgressSystem(
            float executeinverval,
            ITimeService time,
            ISaveLoadService saveLoadService
            )
            : base(executeinverval, time)
        {
            _saveLoadService = saveLoadService;
        }

        protected override void Execute()
        {
            _saveLoadService.SaveProgress();
        }
    }
}
