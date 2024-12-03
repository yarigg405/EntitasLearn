using UnityEngine;


namespace Assets.Code.Gameplay.Common.Visual.StatusVisuals
{
    public sealed class StatusVisuals : MonoBehaviour
    {
        public void ApplyPoison()
        {
            Debug.Log("Poison applied", gameObject);
        }

        public void UnapplyPoison()
        {
            Debug.Log("Poison unapplied", gameObject);
        }

        public void ApplyFreeze()
        {
            Debug.Log("Freeze applied", gameObject);
        }

        public void UnapplyFreeze()
        {
            Debug.Log("Freeze unapplied", gameObject);
        }
    }
}
