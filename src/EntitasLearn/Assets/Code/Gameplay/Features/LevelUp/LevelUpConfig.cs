using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.LevelUp
{
    [CreateAssetMenu(fileName = "LevelUpConfig", menuName = "ScriptableObjects/LevelUpConfig", order = 51)]
    public class LevelUpConfig : ScriptableObject
    {
        public List<float> ExperienceForLevels;
        public int MaxLevel => ExperienceForLevels.Count - 1;
    }
}
