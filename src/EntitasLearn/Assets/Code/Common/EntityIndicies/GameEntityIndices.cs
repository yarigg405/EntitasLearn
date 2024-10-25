using Assets.Code.Gameplay.Features.Effects;
using Assets.Code.Gameplay.Features.Statuses;
using Assets.Code.Gameplay.Features.Statuses.Indexing;
using Entitas;
using System;
using System.Collections.Generic;
using Zenject;


namespace Assets.Code.Common.EntityIndicies
{
    internal sealed class GameEntityIndices : IInitializable
    {
        private readonly GameContext _game;

        public const string StatusesOfType = "StatusesOfType";


        public GameEntityIndices(GameContext game)
        {
            _game = game;
        }

        void IInitializable.Initialize()
        {
            _game.AddEntityIndex(new EntityIndex<GameEntity, StatusKey>(
                name: StatusesOfType,
                _game.GetGroup(GameMatcher.AllOf(
               GameMatcher.StatusTypeId,
               GameMatcher.TargetId,
               GameMatcher.Status,
               GameMatcher.Duration,
               GameMatcher.TimeLeft)),

                getKey: GetTargetStatusKey,
                new StatusKeyEqualityComparer()));
        }

        private StatusKey GetTargetStatusKey(GameEntity entity, IComponent component)
        {
            return new StatusKey(
               (component as TargetId)?.Value ?? entity.TargetId,
               (component as StatusTypeIdComponent)?.Value ?? entity.StatusTypeId);
        }
    }

    public static class ContextIndiciesExtensions
    {
        public static HashSet<GameEntity> TargetStatusesOfType(this GameContext context, StatusTypeId statusTypeId, int targetId)
        {
            return ((EntityIndex<GameEntity, StatusKey>)context.GetEntityIndex(GameEntityIndices.StatusesOfType))
                  .GetEntities(new StatusKey(targetId, statusTypeId));
        }
    }
}
