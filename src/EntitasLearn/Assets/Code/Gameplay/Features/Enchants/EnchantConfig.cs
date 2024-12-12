using Assets.Code.Gameplay.Features.Effects;
using Assets.Code.Gameplay.Features.Statuses;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Enchants
{
    [CreateAssetMenu(fileName = "EnchantConfig", menuName = "ScriptableObjects/EnchantConfig", order = 51)]
    public class EnchantConfig : ScriptableObject
    {
        public EnchantTypeId TypeId;
        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
    }
}
