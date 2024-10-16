﻿using Assets.Code.Gameplay.Features.Abilities.Cooldowns;
using Assets.Code.Infrastructure.Identifiers;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;


namespace Assets.Code.Gameplay.Features.Abilities.Factory
{
    internal sealed class AbilityFactory
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
                .PutOnCooldown();
        }
    }
}
