using Assets.Code.Gameplay.Features.Abilities.Cooldowns;
using Assets.Code.Infrastructure.Identifiers;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;


namespace Assets.Code.Gameplay.Features.Abilities.Factory
{
    public sealed class AbilityFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly StaticDataService _staticDataService;

        public AbilityFactory(IIdentifierService identifiers, StaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateVegetableBoltAbility(int level)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(Configs.AbilityId.VegerableBolt, level);
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddAbilityId(Configs.AbilityId.VegerableBolt)
                .AddCooldown(abilityLevel.CoolDown)
                .With(x => x.isVegetableBoltAbitily = true)
                .With(x => x.isRecreatedOnUpgrade = true)
                .PutOnCooldown();
        }

        public GameEntity CreateOrbitingMushroomAbility(int level)
        {
            var abilityLevel = _staticDataService.GetAbilityLevel(Configs.AbilityId.OrbitingMushroom, level);
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddAbilityId(Configs.AbilityId.OrbitingMushroom)
                .AddCooldown(abilityLevel.CoolDown)
                .With(x => x.isOrbitingMusrhoomAbility = true)
                .With(x => x.isRecreatedOnUpgrade = true)
                .PutOnCooldown();
        }

        public GameEntity CreateGarlicAuraAbility()
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddAbilityId(Configs.AbilityId.GarlicAura)
                .With(x => x.isGarlicAuraAbility = true)
                .With(x => x.isRecreatedOnUpgrade = true);
        }
    }
}
