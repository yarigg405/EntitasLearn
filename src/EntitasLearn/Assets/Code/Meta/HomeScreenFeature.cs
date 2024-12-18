﻿using Assets.Code.Common.Destruct;
using Assets.Code.Meta.Features.Simulation;
using Assets.Code.Meta.Features.Simulation.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Meta
{
    public class HomeScreenFeature : Feature
    {
        public HomeScreenFeature(ISystemFactory systems)
        {
            Add(systems.Create<EmitTickSystem>(MetaConstants.SimulationTickSeconds));

            Add(systems.Create<SimulationFeature>());

            Add(systems.Create<CleanupTickSystem>());
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}
