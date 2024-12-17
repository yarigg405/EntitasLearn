using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Hero.Systems
{
    internal sealed class SetHeroDirectionByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<InputEntity> _inputs;

        public SetHeroDirectionByInputSystem(GameContext game, InputContext input)
        {
            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.MovementAvailable
                ));
            _inputs = input.GetGroup(InputMatcher.Input);
        }

        void IExecuteSystem.Execute()
        {
            foreach (var input in _inputs)
                foreach (var hero in _heroes)
                {
                    hero.isMoving = input.AxisInput != Vector2.zero;
                    hero.ReplaceDirection(input.AxisInput.normalized);
                }
        }
    }
}
