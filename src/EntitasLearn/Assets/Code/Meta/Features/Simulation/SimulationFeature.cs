using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Meta.Features.Simulation.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Meta.Features.Simulation
{
    internal class SimulationFeature : Feature
    {
        public SimulationFeature(ISystemFactory systems)
        {
            Add(systems.Create<BoosterDurationSystem>());
            Add(systems.Create<CalculateGoldGainSystem>());

            Add(systems.Create<AfkGoldGainSystem>());
            Add(systems.Create<UpdateSimulationTimeSystem>());
        }
    }
}
