using Assets.Code.Infrastructure.Serialization;
using Code.Gameplay.Common.Time;
using Code.Progress.Data;
using Code.Progress.Provider;
using System.Linq;
using UnityEngine;


namespace Assets.Code.Progress.SaveLoad
{
    internal class SaveLoadService : ISaveLoadService
    {
        private const string _playerProgressKey = "PlayerProgress";
        private readonly MetaContext _context;
        private readonly IProgressProvider _progress;
        private readonly ITimeService _time;

        bool ISaveLoadService.HasSavedProgress => PlayerPrefs.HasKey(_playerProgressKey);

        public SaveLoadService(MetaContext context, IProgressProvider progress, ITimeService time)
        {
            _context = context;
            _progress = progress;
            _time = time;
        }

        public void SaveProgress()
        {
            PreserveMetaEntities();
            PlayerPrefs.SetString(_playerProgressKey, _progress.ProgressData.ToJson());
            PlayerPrefs.Save();
        }

        public void LoadProgress()
        {
            HydrateProgress(PlayerPrefs.GetString(_playerProgressKey));
        }

        private void HydrateProgress(string serializedProgress)
        {
            _progress.SetProgressData(serializedProgress.FromJson<ProgressData>());
            HydrateMetaEntities();
        }

        private void HydrateMetaEntities()
        {
            var snapshots = _progress.EntityData.MetaEntitySnapshots;
            foreach (var snapshot in snapshots)
            {
                _context
                    .CreateEntity()
                    .HydrateWith(snapshot);
            }
        }

        private void PreserveMetaEntities()
        {
            _progress.EntityData.MetaEntitySnapshots = _context
                .GetEntities()
                .Where(RequiresSave)
                .Select(e => e.AsSavedEntity())
                .ToList()
                ;
        }

        private static bool RequiresSave(MetaEntity e)
        {
            return e.GetComponents().Any(c => c is ISavedComponent);
        }

        void ISaveLoadService.CreateProgress()
        {
            _progress.SetProgressData(new ProgressData()
            {
                LastSimulationTickTime = _time.UtcNow
            });
        }
    }
}
