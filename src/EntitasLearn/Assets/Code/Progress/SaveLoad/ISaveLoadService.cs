namespace Assets.Code.Progress.SaveLoad
{
    public interface ISaveLoadService
    {
        bool HasSavedProgress { get; }

        void CreateProgress();
        void LoadProgress();
        void SaveProgress();
    }
}