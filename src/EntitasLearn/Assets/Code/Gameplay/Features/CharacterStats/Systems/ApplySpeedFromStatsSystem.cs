using Code.Common.Extensions;
using Entitas;


namespace Assets.Code.Gameplay.Features.CharacterStats.Systems
{
    internal sealed class ApplySpeedFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        internal ApplySpeedFromStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.StatModifiers,
                GameMatcher.BaseStats,
                GameMatcher.Speed
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var statOwner in _statOwners)
            {
                statOwner.ReplaceSpeed(MoveSpeed(statOwner).ZeroIfNegative());
            }
        }

        private static float MoveSpeed(GameEntity statOwner)
        {
            return statOwner.BaseStats[Stats.Speed] + statOwner.StatModifiers[Stats.Speed];
        }
    }
}