﻿using Code.Gameplay.Common.Time;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.LevelUp.Systems
{
    internal class StopTimeOnLevelUpSystem:ReactiveSystem<GameEntity>
    {
        private readonly ITimeService _timeService;

        public StopTimeOnLevelUpSystem(GameContext game, ITimeService timeService) : base(game)
        {
            _timeService = timeService;
        }


        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.LevelUp.Added());

        protected override bool Filter(GameEntity entity) => true;

        protected override void Execute(List<GameEntity> levelUps)
        {
            foreach (var _ in levelUps)
            {
                _timeService.StopTime();
            }
        }
    }
}
