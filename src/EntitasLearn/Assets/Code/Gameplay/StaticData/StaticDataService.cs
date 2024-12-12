using Assets.Code.Gameplay.Features.Abilities.Configs;
using Assets.Code.Gameplay.Features.Enchants;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Code.Gameplay.StaticData
{
    internal class StaticDataService
    {
        private Dictionary<AbilityId, AbilityConfig> _abilities;
        private Dictionary<EnchantTypeId, EnchantConfig> _enchants;

        public StaticDataService()
        {
            LoadAll();
            LoadEnchants();
        }

        public void LoadAll()
        {
            LoadAbilities();
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
    }
}