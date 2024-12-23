﻿using Assets.Code.Gameplay.Features.Enchants.Systems;
using Assets.Code.Gameplay.Features.Statuses.Systems.StatusVisuals;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.Statuses.Systems
{
    internal sealed class StatusVisualsFeature : Feature
    {
        public StatusVisualsFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyPoisonVisualsSystem>());
            Add(systems.Create<UnapplyPoisonVisualsSystem>());

            Add(systems.Create<ApplyFreezeVisualsSystem>());
            Add(systems.Create<UnapplyFreezeVisualsSystem>());

            Add(systems.Create<RemoveUnappliedEnchantsIconFromHolder>());
        }
    }
}
