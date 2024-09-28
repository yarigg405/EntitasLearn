using UnityEngine;


namespace Assets.Code.Gameplay.Features.Hero
{
    public sealed class HeroAnimator:MonoBehaviour
    {
        [SerializeField] private Animator anim;

        private readonly int _isMovingHash = Animator.StringToHash("isMoving");
        private readonly int _attackHash = Animator.StringToHash("attack");
        private readonly int _diedHash = Animator.StringToHash("died");
        private readonly int _damageHash = Animator.StringToHash("damage");

        public void PlayMove()
        {
            anim.SetBool(_isMovingHash, true);
        }

        public void PlayIdle()
        {
            anim.SetBool(_isMovingHash, false);
        }

        public void PlayDamageTaken()
        {
            anim.SetTrigger(_damageHash);
        }
    }
}
