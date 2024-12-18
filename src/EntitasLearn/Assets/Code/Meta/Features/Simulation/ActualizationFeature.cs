﻿using Assets.Code.Common.Destruct;
using Code.Infrastructure.Systems;


namespace Assets.Code.Meta.Features.Simulation
{
    public class ActualizationFeature : Feature
    {
        public ActualizationFeature(ISystemFactory systems)
        {
            Add(systems.Create<SimulationFeature>());
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}
