﻿using Assets.Code.Common.Destruct;
using Assets.Code.Gameplay.Features.Abilities;
using Assets.Code.Gameplay.Features.Abilities.Armaments;
using Assets.Code.Gameplay.Features.CharacterStats;
using Assets.Code.Gameplay.Features.DamageApplication;
using Assets.Code.Gameplay.Features.Effects;
using Assets.Code.Gameplay.Features.Enchants;
using Assets.Code.Gameplay.Features.Enemies;
using Assets.Code.Gameplay.Features.GameOver.Systems;
using Assets.Code.Gameplay.Features.Hero;
using Assets.Code.Gameplay.Features.LevelUp;
using Assets.Code.Gameplay.Features.Lifetime;
using Assets.Code.Gameplay.Features.Loot;
using Assets.Code.Gameplay.Features.Movement;
using Assets.Code.Gameplay.Features.Statuses;
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
            Add(systems.Create<DeathFeature>());

            Add(systems.Create<LootFeature>());
            Add(systems.Create<LevelUpFeature>());

            Add(systems.Create<MovementFeature>());
            Add(systems.Create<AbilitiesFeature>());
            Add(systems.Create<ArmamentFeature>());             

            Add(systems.Create<CollectTargetsFeature>());
            Add(systems.Create<EffectApplicationFeature>());

            Add(systems.Create<EnchantFeature>());
            Add(systems.Create<EffectsFeature>());
            Add(systems.Create<StatusFeature>());
            Add(systems.Create<StatsFeature>());

            Add(systems.Create<GameOverOnHeroDeathSystem>());

            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}
