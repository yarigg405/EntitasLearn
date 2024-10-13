using Assets.Code.Gameplay.Features.Effects;
using Assets.Code.Infrastructure.View;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Abilities.Configs
{
    [Serializable]
    internal struct AbilityLevel
    {
        public float CoolDown;
        public EntityBehaviour ViewPrefab;

        public List<EffectSetup> EffectSetups;

        [Space]
        public ProjectileSetup ProjectileSetup;
    }
}
