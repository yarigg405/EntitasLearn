﻿using Entitas;


namespace Assets.Code.Gameplay.Features.Effects
{
    internal static class EffectEntityExtestions
    {
        private static GameContext GameContext => Contexts.sharedInstance.game;

        public static GameEntity Producer(this GameEntity effect)
        {
            return
                 effect.hasProducerId
                 ? GameContext.GetEntityWithId(effect.ProducerId)
                 : null;
        }

        public static GameEntity Target(this GameEntity effect)
        {
            return
                effect.hasTargetId
                ? GameContext.GetEntityWithId(effect.TargetId)
                : null;
        }
    }
}