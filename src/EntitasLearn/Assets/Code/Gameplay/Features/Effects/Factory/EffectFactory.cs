using Assets.Code.Infrastructure.Identifiers;
using Code.Common.Entity;
using Code.Common.Extensions;
using System;


namespace Assets.Code.Gameplay.Features.Effects.Factory
{
    internal sealed class EffectFactory
    {
        private readonly IIdentifierService _identifiers;

        public EffectFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId)
        {
            switch (setup.EffectTypeId)
            {
                case EffectTypeId.None:
                    break;

                case EffectTypeId.Damage:
                    return CreateDamage(producerId, targetId, setup.Value);
            }

            throw new Exception($"Effect with type not found: {setup.EffectTypeId}");
        }

        private GameEntity CreateDamage(int producerId, int targetId, float value)
        {
            return CreateEntity.Empty()
                  .AddId(_identifiers.Next())
                  .With(x => x.isEffect = true)
                  .With(x => x.isDamageEffect = true)
                  .AddEffectValue(value)
                  .AddProducerId(producerId)
                  .AddTargetId(targetId)
                  ;
        }
    }
}