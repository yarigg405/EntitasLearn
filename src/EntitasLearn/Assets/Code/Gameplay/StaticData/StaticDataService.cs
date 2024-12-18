using Assets.Code.Gameplay.Features.Abilities.Configs;
using Assets.Code.Gameplay.Features.Enchants;
using Assets.Code.Gameplay.Features.LevelUp;
using Assets.Code.Gameplay.Features.Loot;
using Assets.Code.Gameplay.Features.Loot.Configs;
using Assets.Code.Meta.Features.AfkGain.Configs;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Code.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<AbilityId, AbilityConfig> _abilities;
        private Dictionary<EnchantTypeId, EnchantConfig> _enchants;
        private Dictionary<LootTypeId, LootConfig> _loot;
        private Dictionary<WindowId, GameObject> _windows;
        private LevelUpConfig _levelup;
        private AfkGainConfig _afkGainConfig;

        public StaticDataService()
        {
            LoadAll();
        }
        public void LoadAll()
        {
            LoadAbilities();
            LoadEnchants();
            LoadLoot();
            LoadWindows();
            LoadLevelUpRules();
            LoadAfkGainConfigs();
        }

        private void LoadAbilities()
        {
            _abilities = Resources
                .LoadAll<AbilityConfig>("Configs/Abilities")
                .ToDictionary(x => x.AbilityId, x => x);
        }
        private void LoadEnchants()
        {
            _enchants = Resources
               .LoadAll<EnchantConfig>("Configs/Enchants")
               .ToDictionary(x => x.TypeId, x => x);
        }
        private void LoadLoot()
        {
            _loot = Resources
               .LoadAll<LootConfig>("Configs/Loot")
               .ToDictionary(x => x.LootTypeId, x => x);
        }
        private void LoadWindows()
        {
            _windows = Resources
                .Load<WindowsConfig>("Configs/Windows/windowConfig")
                .WindowConfigs
                .ToDictionary(x => x.Id, x => x.Prefab);
        }

        private void LoadLevelUpRules()
        {
            _levelup = Resources
               .Load<LevelUpConfig>("Configs/LevelUp/levelUpConfig");

        }        

        private void LoadAfkGainConfigs()
        {
            _afkGainConfig = Resources
               .Load<AfkGainConfig>("Configs/AfkGainConfig");

        }



        internal AbilityConfig GetAbilityConfig(AbilityId id)
        {
            if (_abilities.TryGetValue(id, out var config))
            {
                return config;
            }

            throw new System.Exception($"Ability with id not found: {id}");
        }

        internal AbilityLevel GetAbilityLevel(AbilityId id, int level)
        {
            var config = GetAbilityConfig(id);

            if (level > config.AbilityLevels.Length)
                level = config.AbilityLevels.Length;

            return config.AbilityLevels[level - 1];
        }

        internal EnchantConfig GetEnchantConfig(EnchantTypeId id)
        {
            if (_enchants.TryGetValue(id, out var config))
            {
                return config;
            }

            throw new System.Exception($"Enchant with id not found: {id}");
        }

        internal LootConfig GetLootConfig(LootTypeId id)
        {
            if (_loot.TryGetValue(id, out var config))
            {
                return config;
            }

            throw new System.Exception($"Loot with id not found: {id}");
        }

        internal GameObject GetWindowPrefab(WindowId id)
        {
            if (_windows.TryGetValue(id, out var config))
            {
                return config;
            }

            throw new System.Exception($"Window with id not found: {id}");
        }

        public int MaxLevel() => _levelup.MaxLevel;
        public float GetExperienceForLevel(int level)
        {
            return _levelup.ExperienceForLevels[level];
        }

        public AfkGainConfig AfkGain => _afkGainConfig;
    }
}