using Assets.Code.Gameplay.Features.Statuses;
using Code.Gameplay.StaticData;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Enchants.Systems
{
    internal sealed class PoisonEnchantSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enchants;
        private readonly IGroup<GameEntity> _armaments;
        private readonly List<GameEntity> _buffer = new(32);
        private readonly StaticDataService _staticDataService;


        internal PoisonEnchantSystem(GameContext game, StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _enchants = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.EnchantTypeId,
                GameMatcher.ProducerId,
                GameMatcher.PoisonEnchant
            ));

            _armaments = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Armament,
                GameMatcher.ProducerId)
            .NoneOf(GameMatcher.PoisonEnchant));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var enchant in _enchants)
                foreach (var armament in _armaments.GetEntities(_buffer))
                {
                    if (enchant.ProducerId == armament.ProducerId)
                    {
                        GetOrAddStatusSetups(armament)
                            .AddRange(_staticDataService.GetEnchantConfig(EnchantTypeId.PoisonArmaments).StatusSetups);

                        armament.isPoisonEnchant = true;
                    }
                }
        }

        private static List<StatusSetup> GetOrAddStatusSetups(GameEntity armament)
        {
            if (!armament.hasStatusSetups)
                armament.AddStatusSetups(new List<StatusSetup>());

            return armament.StatusSetups;
        }
    }
}