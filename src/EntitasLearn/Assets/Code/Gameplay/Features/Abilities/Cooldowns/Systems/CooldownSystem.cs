using Code.Gameplay.Common.Time;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Abilities.Cooldowns.Systems
{
    internal sealed partial class CooldownSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _time;
        private readonly List<GameEntity> _buffer = new(32);

        internal CooldownSystem(GameContext game, ITimeService timeService)
        {
            _time = timeService;

            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Cooldown,
                GameMatcher.CooldownLeft
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity.ReplaceCooldownLeft(entity.CooldownLeft - _time.DeltaTime);

                if (entity.CooldownLeft <= 0)
                {
                    entity.isCooldownIsUp = true;
                    entity.RemoveCooldownLeft();
                }
            }
        }
    }
}