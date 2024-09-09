﻿using Code.Common.Entity;
using Entitas;


namespace Assets.Code.Gameplay.Input.Systems
{
    internal sealed class InitializeInputSystem : IInitializeSystem
    {
        void IInitializeSystem.Initialize()
        {
            CreateEntity.Empty()
                 .isInput = true;
        }
    }
}