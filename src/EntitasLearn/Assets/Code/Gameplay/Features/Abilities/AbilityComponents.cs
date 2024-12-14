using Assets.Code.Gameplay.Features.Abilities.Configs;
using Entitas;
using Entitas.CodeGeneration.Attributes;


namespace Assets.Code.Gameplay.Features.Abilities
{
    public sealed class AbilityComponents
    {
        [Game] public class AbilityIdComponent : IComponent { public AbilityId Value; }
        [Game] public class ParentAbility : IComponent { [EntityIndex] public AbilityId Value; }
        [Game] public class VegetableBoltAbitily : IComponent { }
        [Game] public class OrbitingMusrhoomAbility : IComponent { }
        [Game] public class GarlicAuraAbility : IComponent { }
        [Game] public class UpgradeRequest : IComponent { }
        [Game] public class RecreatedOnUpgrade : IComponent { }
    }
}
