using Assets.Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Input
{
    internal sealed class InputFeature : Feature
    {
        public InputFeature(ISystemFactory systems)
        {
            Add(systems.Create<InitializeInputSystem>());
            Add(systems.Create<EmitInputSystem>());
        }
    }
}
