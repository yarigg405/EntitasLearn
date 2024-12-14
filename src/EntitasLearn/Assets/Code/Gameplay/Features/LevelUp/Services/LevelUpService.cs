using Code.Common.Entity;
using Code.Gameplay.StaticData;


namespace Assets.Code.Gameplay.Features.LevelUp.Services
{
    public class LevelUpService
    {
        private readonly StaticDataService _staticData;

        public float CurrentExperience { get; private set; }
        public int CurrentLevel { get; private set; }


        public LevelUpService(StaticDataService staticData)
        {
            _staticData = staticData;
        }

        public void AddExperience(float experience)
        {
            CurrentExperience += experience;
            UpdateLevel();
        }

        private void UpdateLevel()
        {
            if (CurrentLevel >= _staticData.MaxLevel())
                return;

            float experienceForLevelUp = _staticData.GetExperienceForLevel(CurrentLevel + 1);
            if (CurrentExperience < experienceForLevelUp)
                return;

            CurrentExperience -= experienceForLevelUp;
            CurrentLevel++;

            CreateEntity.Empty()
                .isLevelUp = true;

            UpdateLevel();
        }

        public float ExperienceForLevelUp()
        {
            return _staticData.GetExperienceForLevel(CurrentLevel + 1);
        }
    }
}
