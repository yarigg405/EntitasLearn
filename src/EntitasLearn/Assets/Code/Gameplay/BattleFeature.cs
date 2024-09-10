using Assets.Code.Common.Destruct;
using Assets.Code.Gameplay.Features.Enemies;
using Assets.Code.Gameplay.Features.Hero;
using Assets.Code.Gameplay.Features.Movement;
using Assets.Code.Gameplay.Input;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay
{
    internal sealed class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<HeroFeature>());
            Add(systems.Create<EnemyFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}
