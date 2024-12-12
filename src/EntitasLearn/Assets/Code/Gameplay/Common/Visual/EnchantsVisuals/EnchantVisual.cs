using UnityEngine;


namespace Assets.Code.Gameplay.Common.Visual.EnchantsVisuals
{
    public sealed class EnchantVisual : MonoBehaviour
    {
        [SerializeField] private GameObject freezeVisualRoot;
        [SerializeField] private GameObject poisonVisualRoot;

        internal void ApplyFreeze()
        {
            freezeVisualRoot.SetActive(true);
        }

        internal void UnapplyFreeze()
        {
            freezeVisualRoot.SetActive(false);
        }


        internal void ApplyPoison()
        {
            poisonVisualRoot.SetActive(true);
        }

        internal void UnapplyPoison()
        {
            poisonVisualRoot.SetActive(false);
        }
    }
}
