using Assets.Code.Gameplay.Features.TargetCollection;
using Entitas;


namespace Assets.Code.Gameplay.Features.Abilities.Armaments.Systems
{
    internal sealed class FinalizeProcessedArmamentsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;

        internal FinalizeProcessedArmamentsSystem(GameContext game)
        {
            _armaments = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Armament,
                GameMatcher.Processed
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _armaments)
            {
                entity.RemoveTargetCollectionComponents();
                entity.isDestructed = true;
            }
        }
    }
}