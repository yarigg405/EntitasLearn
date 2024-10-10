using Assets.Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Entitas;


namespace Assets.Code.Gameplay.Features.Hero.Systems
{
    internal sealed class InitializeHeroSystem : IInitializeSystem
    {
        private readonly IHeroFactory _heroFactory;
        private readonly ILevelDataProvider _levelDataProvider;

        public InitializeHeroSystem(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider)
        {
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
        }

        void IInitializeSystem.Initialize()
        {
            _heroFactory.CreateHero(_levelDataProvider.StartPoint);
        }
    }
}
