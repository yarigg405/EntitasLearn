﻿using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Enchants.Systems
{
    public class ApplyPoisonEnchantVisualsSystem : ReactiveSystem<GameEntity>
    {
        public ApplyPoisonEnchantVisualsSystem(GameContext game) : base(game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
        context.CreateCollector(GameMatcher
         .AllOf(
           GameMatcher.EnchantVisuals,
           GameMatcher.Armament,
           GameMatcher.PoisonEnchant)
         .Added());

        protected override bool Filter(GameEntity entity) =>
            entity.isArmament && entity.hasEnchantVisuals;

        protected override void Execute(List<GameEntity> armaments)
        {
            foreach (var entity in armaments)
            {
                entity.EnchantVisuals.ApplyPoison();
            }
        }
    }
}
