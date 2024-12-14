﻿using Assets.Code.Gameplay.Features.LevelUp.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.LevelUp
{
    internal class LevelUpFeature : Feature
    {
        public LevelUpFeature(ISystemFactory systems)
        {
            Add(systems.Create<OpenLevelUpWindowSystem>());
            Add(systems.Create<StopTimeOnLevelUpSystem>());
           
            Add(systems.Create<UpgradeAbilityOnRequestSystem>()); 
            Add(systems.Create<StartTimeOnLevelUpProcessedSystem>());

            Add(systems.Create<FinalizeProcessedLevelUps>());
        }
    }
}
