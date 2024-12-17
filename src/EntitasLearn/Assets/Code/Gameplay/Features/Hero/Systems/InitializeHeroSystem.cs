using Assets.Code.Gameplay.Features.Abilities.Factory;
using Assets.Code.Gameplay.Features.Hero.Factory;
using Assets.Code.Gameplay.Features.Statuses.Applier;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Levels;
using Entitas;


namespace Assets.Code.Gameplay.Features.Hero.Systems
{
    internal sealed class InitializeHeroSystem : IInitializeSystem
    {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly StatusApplier _statusApplier;
        private readonly IAbilityUpgradeService _upgradeService;

        public InitializeHeroSystem(
            IHeroFactory heroFactory,
            ILevelDataProvider levelDataProvider,
            AbilityFactory abilityFactory,
            StatusApplier statusApplier,
            IAbilityUpgradeService upgradeService
            )
        {
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
            _statusApplier = statusApplier;
            _upgradeService = upgradeService;
        }

        void IInitializeSystem.Initialize()
        {
            _upgradeService.InitializeAbility(Abilities.Configs.AbilityId.VegerableBolt);
        }
    }
}
