using UnityEngine;
using UnityEngine.UI;


namespace Assets.Code.Gameplay.Features.Enchants.Behaviours
{
    internal sealed class EnchantIcon : MonoBehaviour
    {
        public Image Icon;
        public EnchantTypeId TypeId;

        public void Set(EnchantConfig config)
        {
            TypeId = config.TypeId;
            Icon.sprite = config.Icon;            
        }
    }
}
