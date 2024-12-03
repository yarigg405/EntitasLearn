using Assets.Code.Gameplay.Features.Effects;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Statuses.Systems.StatusVisuals
{
    internal sealed class ApplyFreezeVisualsSystem : ReactiveSystem<GameEntity>
    {
        public ApplyFreezeVisualsSystem(GameContext game) : base(game) { }


        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Freeze.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isStatus && entity.isFreeze && entity.hasTargetId;
        }

        protected override void Execute(List<GameEntity> statuses)
        {
            foreach (var status in statuses)
            {
                GameEntity target = status.Target();
                if (target is { hasStatusVisuals: true })
                {
                    target.StatusVisuals.ApplyFreeze();
                }
            }
        }
    }
}
