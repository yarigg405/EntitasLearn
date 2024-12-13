using Assets.Code.Gameplay.Features.Effects;
using Assets.Code.Gameplay.Features.Statuses;
using Assets.Code.Infrastructure.View;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Loot.Configs
{
    [CreateAssetMenu(fileName = "LootConfig", menuName = "ScriptableObjects/LootConfig", order = 51)]
    public class LootConfig : ScriptableObject
    {
        public LootTypeId LootTypeId;
        public float Experience;
        public EntityBehaviour ViewPrefab;

        public List<EffectSetup> Effects;
        public List<StatusSetup> Statuses;
    }
}
