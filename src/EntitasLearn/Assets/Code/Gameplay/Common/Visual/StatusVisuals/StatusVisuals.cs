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
    }
}
