using Assets.Code.Gameplay.Common.Visual;
using DG.Tweening;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Enemies
{
    public sealed class EnemyAnimator : MonoBehaviour, IDamageTakenAnimator
    {
        [SerializeField] private Animator anim;
        [SerializeField] private SkinnedMeshRenderer mRenderer;

        private static readonly int OverlayIntensityProperty = Shader.PropertyToID("_OverlayIntensity");
        private readonly int _diedHash = Animator.StringToHash("die");
        private readonly int _damageHash = Animator.StringToHash("damage");

        private Material Material => mRenderer.material;

        public void PlayDamageTaken()
        {
            anim.SetTrigger(_damageHash);

            if (DOTween.IsTweening(Material))
                return;

            Material.DOFloat(0.4f, OverlayIntensityProperty, 0.15f)
              .OnComplete(() =>
              {
                  if (mRenderer)
                      Material.DOFloat(0, OverlayIntensityProperty, 0.15f);
              });
        }

        public void PlayeDeath()
        {
            anim.SetTrigger(_diedHash);
        }
    }
}
