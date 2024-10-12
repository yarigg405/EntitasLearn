using Assets.Code.Gameplay.Features.Abilities.Configs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Code.Gameplay.StaticData
{
    internal class StaticDataService
    {
        private Dictionary<AbilityId, AbilityConfig> _abilities;

        public StaticDataService()
        {
            LoadAll();
        }

        public void LoadAll()
        {
            LoadAbilities();
        }

        internal AbilityConfig GetAbilityConfig(AbilityId id)
        {
            if (_abilities.TryGetValue(id, out var abilityConfig))
            {
                return abilityConfig;
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

        private void LoadAbilities()
        {
            _abilities = Resources
                .LoadAll<AbilityConfig>("Configs/Abilities")
                .ToDictionary(x => x.AbilityId, x => x);
        }
    }
}