using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Input.Systems
{
    internal sealed class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _InputService;

        private readonly IGroup<InputEntity> _inputs;

        public EmitInputSystem(InputContext context, IInputService inputService)
        {
            _InputService = inputService;
            _inputs = context.GetGroup(InputMatcher.Input);
        }

        void IExecuteSystem.Execute()
        {
            foreach (var input in _inputs)
            {
                input.ReplaceAxisInput(new Vector2(_InputService.GetHorizontalAxis(), _InputService.GetVerticalAxis()));
            }
        }
    }
}
