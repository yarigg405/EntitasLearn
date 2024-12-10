using Assets.Code.Gameplay.Features.Abilities.Cooldowns.Systems;
using Assets.Code.Gameplay.Features.Abilities.Systems;
using Code.Infrastructure.Systems;


namespace Assets.Code.Gameplay.Features.Abilities
{
    internal sealed class AbilitiesFeature : Feature
    {
        public AbilitiesFeature(ISystemFactory systems)
        {
            Add(systems.Create<CooldownSystem>());
            Add(systems.Create<VegetableBoltAbilitySystem>());
            Add(systems.Create<OrbitingMushroomAbilitySystem>());
        }
    }
}
