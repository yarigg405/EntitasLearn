using Entitas;
using System;
using UnityEngine.Assertions.Must;


namespace Assets.Code.Gameplay.Features.Hero.Systems
{
    internal sealed class SetHeroDirectionByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _inputs;

        public SetHeroDirectionByInputSystem(GameContext context)
        {
            _heroes = context.GetGroup(GameMatcher.Hero);
            _inputs = context.GetGroup(GameMatcher.Input);
        }

        void IExecuteSystem.Execute()
        {
            foreach (var input in _inputs)
                foreach (var hero in _heroes)
                {
                    hero.isMoving = input.hasAxisInput;

                    if (input.hasAxisInput)
                    {
                        hero.ReplaceDirection(input.AxisInput.normalized);
                    }
                }
        }
    }
}
