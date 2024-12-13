using Assets.Code.Infrastructure.Identifiers;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Loot.Factory
{
    internal class LootFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly StaticDataService _staticData;

        public LootFactory(IIdentifierService identifiers, StaticDataService staticDataService)
        {
            _identifiers = identifiers;
            _staticData = staticDataService;
        }

        public GameEntity CreateLootItem(LootTypeId typeId, Vector3 spawnPos)
        {
            var config = _staticData.GetLootConfig(typeId);
            return CreateEntity.Empty()
                 .AddId(_identifiers.Next())
                 .AddWorldPosition(spawnPos)
                 .AddViewPrefab(config.ViewPrefab)

                 .With(x => x.AddExperience(config.Experience), when: config.Experience > 0)
                 .With(x => x.AddEffectSetups(config.Effects), when: !config.Effects.IsNullOrEmpty())
                 .With(x => x.AddStatusSetups(config.Statuses), when: !config.Statuses.IsNullOrEmpty())
                 .With(x => x.isPullable = true)
                ;
        }
    }
}


