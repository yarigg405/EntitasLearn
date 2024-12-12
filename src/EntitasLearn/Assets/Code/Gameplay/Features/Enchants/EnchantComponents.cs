using Assets.Code.Gameplay.Common.Visual.EnchantsVisuals;
using Entitas;


namespace Assets.Code.Gameplay.Features.Enchants
{
    [Game] public class EnchantTypeIdComponent : IComponent { public EnchantTypeId Value; }
    [Game] public class EnchantVisualsComponent : IComponent { public EnchantVisual Value; }
    [Game] public class PoisonEnchant : IComponent { }
    [Game] public class ExplosiveEnchant : IComponent { }
}
