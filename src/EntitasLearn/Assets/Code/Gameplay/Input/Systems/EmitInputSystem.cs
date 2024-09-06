using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Input.Systems
{
    internal sealed class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _InputService;

        private readonly IGroup<GameEntity> _inputs;

        public EmitInputSystem(GameContext context, IInputService inputService)
        {
            _InputService = inputService;
            _inputs = context.GetGroup(GameMatcher.Input);
        }

        void IExecuteSystem.Execute()
        {
            foreach (var input in _inputs)
            {
                if (_InputService.HasAxisInput())
                {
                    input.ReplaceAxisInput(new Vector2(_InputService.GetHorizontalAxis(), _InputService.GetVerticalAxis()));
                }
                else if (input.hasAxisInput)
                {
                    input.RemoveAxisInput();
                }
            }
        }
    }
}
