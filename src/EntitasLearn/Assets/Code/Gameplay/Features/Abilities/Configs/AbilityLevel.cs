using Assets.Code.Infrastructure.View;
using System;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Abilities.Configs
{
    [Serializable]
    internal struct AbilityLevel
    {
        public float CoolDown;
        public EntityBehaviour ViewPrefab;

        [Space]
        public ProjectileSetup ProjectileSetup;
    }
}
