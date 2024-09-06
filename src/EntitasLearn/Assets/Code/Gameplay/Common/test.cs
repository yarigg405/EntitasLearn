using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace EntitasLearn
{
    internal sealed class test : MonoBehaviour
    {
        private void Start()
        {
            GameEntity entity = null;

            entity
                .AddId(0)
                .AddWorldPosition(Vector3.zero);
        }

    }
}