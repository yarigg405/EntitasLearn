using Assets.Code.Common.EntityIndicies;
using Code.Common.Entity;
using Entitas;


namespace Assets.Code.Gameplay.Features.CharacterStats.Systems
{
    internal sealed class StatChangeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;
        private readonly GameContext _game;

        internal StatChangeSystem(GameContext game)
        {
            _game = game;

            _statOwners = game.GetGroup(GameMatcher.AllOf(
               GameMatcher.Id,
               GameMatcher.BaseStats,
               GameMatcher.StatModifiers
           ));
        }

        void IExecuteSystem.Execute()
        {


            foreach (var owner in _statOwners)
                foreach (var stat in owner.BaseStats.Keys)
                {
                    owner.StatModifiers[stat] = 0;
                    foreach (var change in _game.TargetStatChanges(stat, owner.Id))
                    {
                        owner.StatModifiers[stat] += change.EffectValue;
                    }
                }
        }
    }
}