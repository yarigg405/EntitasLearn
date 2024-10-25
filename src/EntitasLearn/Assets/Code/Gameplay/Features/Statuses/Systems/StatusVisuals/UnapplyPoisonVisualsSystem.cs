using Assets.Code.Gameplay.Features.Effects;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Statuses.Systems.StatusVisuals
{
    internal sealed class UnapplyPoisonVisualsSystem : ReactiveSystem<GameEntity>
    {
        public UnapplyPoisonVisualsSystem(GameContext game) : base(game) { }


        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(
                GameMatcher.Poison,
                GameMatcher.Status,
                GameMatcher.Unapplied)
                .Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isStatus && entity.isPoison && entity.hasTargetId;
        }

        protected override void Execute(List<GameEntity> statuses)
        {
            foreach (var status in statuses)
            {
                GameEntity target = status.Target();
                if (target is { hasStatusVisuals: true })
                {
                    target.StatusVisuals.UnapplyPoison();
                }
            }
        }
    }
}
