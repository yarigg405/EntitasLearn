using Assets.Code.Gameplay.Features.Abilities.Configs;
using Code.Common.Entity;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using System;
using UnityEngine;
using Zenject;


namespace Assets.Code.Gameplay.Features.LevelUp.Windows
{
    public sealed class LevelUpWindow : BaseWindow
    {
        public Transform AbilityLayout;

        private IAbilityUpgradeService _upgradeService;
        private AbilityUiFactory _abilityUiFactory;
        private StaticDataService _staticDataService;
        private IWindowService _windowService;


        [Inject]
        private void Construct(
            AbilityUiFactory factory, 
            IAbilityUpgradeService upgradeService,
            StaticDataService staticDataService,
            IWindowService windowService)
        {
            Id = WindowId.LevelUpWindow;

            _upgradeService = upgradeService;
            _abilityUiFactory = factory;
            _staticDataService = staticDataService;
            _windowService = windowService;
        }

        protected override void Initialize()
        {
            foreach (var option in _upgradeService.GetUpgradeOptions())
            {
               var level = _staticDataService.GetAbilityLevel(option.Id, option.Level);

                _abilityUiFactory.CreateAbilityCard(AbilityLayout)
                    .Setup(option.Id, level, OnSelected);

            }

        }

        private void OnSelected(AbilityId id)
        {
            CreateEntity.Empty()
                .AddAbilityId(id)
                .isUpgradeRequest = true;

            _windowService.Close(Id);
        }
    }
}
