using UnityEngine;
using Yrr.UI.Elements;


namespace Assets.Code.Gameplay.Features.LevelUp.Behaviours
{
    public sealed class ExperienceMeter : MonoBehaviour
    {
        [SerializeField] private SmoothSlider progressBar;

        private void Start()
        {
            progressBar.InitValue(0);
        }

        public void SetExperience(float currentXp, float maxXp)
        {
            progressBar.ChangeValue(currentXp / maxXp);
        }
    }
}
