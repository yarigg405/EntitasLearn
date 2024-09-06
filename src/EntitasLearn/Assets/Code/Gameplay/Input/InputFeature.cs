using Assets.Code.Gameplay.Input.Systems;
using Code.Gameplay.Input.Service;


namespace Assets.Code.Gameplay.Input
{
    internal sealed class InputFeature : Feature
    {
        public InputFeature(GameContext context, IInputService inputService)
        {
            Add(new InitializeInputSystem());
            Add(new EmitInputSystem(context, inputService));
        }
    }
}
