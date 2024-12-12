﻿using Assets.Code.Gameplay.Features.Enchants.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.Enchants
{
    internal sealed class EnchantFeature : Feature
    {
        public EnchantFeature(ISystemFactory systems)
        {
            Add(systems.Create<PoisonEnchantSystem>());
            Add(systems.Create<ExplosiveEnchantSystem>());

            Add(systems.Create<ApplyPoisonEnchantVisualsSystem>());
        }
    }
}
