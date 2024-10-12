using Assets.Code.Gameplay.Features.Abilities.Configs;
using Entitas;


namespace Assets.Code.Gameplay.Features.Abilities
{
    public sealed class AbilityComponents
    {
        [Game] public class AbilityIdComponent : IComponent { public AbilityId Value; }
        [Game] public class VegetableBoltAbitily : IComponent { }
    }
}
