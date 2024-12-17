namespace Code.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        float GetExperienceForLevel(int level);
        void LoadAll();
        int MaxLevel();
    }
}