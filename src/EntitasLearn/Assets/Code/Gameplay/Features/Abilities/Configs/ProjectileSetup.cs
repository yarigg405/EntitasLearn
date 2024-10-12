using System;


namespace Assets.Code.Gameplay.Features.Abilities.Configs
{
    [Serializable]
    internal struct ProjectileSetup
    {
        public float Speed;
        public int Pierce;
        public float ContactRadius;
        public float Lifetime;
    }
}
