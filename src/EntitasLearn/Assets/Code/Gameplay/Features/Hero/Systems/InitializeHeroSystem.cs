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
            //var hero = _heroFactory.CreateHero(_levelDataProvider.StartPoint);

            _upgradeService.InitializeAbility(Abilities.Configs.AbilityId.VegerableBolt);

            //  _abilityFactory.CreateOrbitingMushroomAbility(1);

            // _abilityFactory.CreateGarlicAuraAbility();

            //_statusApplier.ApplyStatus(new StatusSetup()
            //{
            //    StatusTypeId = StatusTypeId.PoisonEnchant,
            //    Duration = 10f
            //}, 
            //hero.Id, hero.Id); 
            
            //_statusApplier.ApplyStatus(new StatusSetup()
            //{
            //    StatusTypeId = StatusTypeId.ExplosiveEnchant,
            //    Duration = 90f
            //}, 
            //hero.Id, hero.Id);
        }
    }
}
