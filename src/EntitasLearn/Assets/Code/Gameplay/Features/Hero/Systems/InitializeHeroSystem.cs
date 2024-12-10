using Assets.Code.Gameplay.Features.Abilities.Factory;
using Assets.Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Entitas;


namespace Assets.Code.Gameplay.Features.Hero.Systems
{
    internal sealed class InitializeHeroSystem : IInitializeSystem
    {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly AbilityFactory _abilityFactory;

        public InitializeHeroSystem(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider, AbilityFactory abilityFactory)
        {
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
            _abilityFactory = abilityFactory;
        }

        void IInitializeSystem.Initialize()
        {
            _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            _abilityFactory.CreateVegetableBoltAbility(1);
          //  _abilityFactory.CreateOrbitingMushroomAbility(1);
            _abilityFactory.CreateGarlicAuraAbility();
        }
    }
}
