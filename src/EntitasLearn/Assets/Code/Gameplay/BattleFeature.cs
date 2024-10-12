using Assets.Code.Common.Destruct;
using Assets.Code.Gameplay.Features.Abilities;
using Assets.Code.Gameplay.Features.Abilities.Armaments;
using Assets.Code.Gameplay.Features.DamageApplication;
using Assets.Code.Gameplay.Features.Enemies;
using Assets.Code.Gameplay.Features.Hero;
using Assets.Code.Gameplay.Features.Lifetime;
using Assets.Code.Gameplay.Features.Movement;
using Assets.Code.Gameplay.Features.TargetCollection;
using Assets.Code.Gameplay.Input;
using Assets.Code.Infrastructure.View;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay
{
    internal sealed class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<BindViewFeature>());
            Add(systems.Create<HeroFeature>());
            Add(systems.Create<EnemyFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<AbilitiesFeature>());
            Add(systems.Create<ArmamentFeature>());
            Add(systems.Create<DeathFeature>());                  
            Add(systems.Create<CollectTargetsFeature>());
            Add(systems.Create<DamageApplicationFeature>());
            Add(systems.Create<ProcessDestructedFeature>());           
        }
    }
}
