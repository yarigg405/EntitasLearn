using Assets.Code.Gameplay.Common.Physics;
using Code.Common.Extensions;
using Entitas;


namespace Assets.Code.Gameplay.Features.Loot.Systems
{
    internal sealed class CastForPullablesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _looters;
        private readonly IPhysicsService _physicsService;
        private readonly int _layerMask = CollisionLayer.Collectable.AsMask();
        private readonly GameEntity[] _hitBuffer = new GameEntity[128];

        internal CastForPullablesSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _looters = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Transform,
                GameMatcher.PickupRadius
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var looter in _looters)
            {
                for (int i = 0; i < LootinRadius(looter); i++)
                {
                    if (_hitBuffer[i].isPullable)
                    {
                        _hitBuffer[i].isPullable = false;
                        _hitBuffer[i].isPulling = true;
                    }
                }

                ClearBuffer();
            }
        }

        private void ClearBuffer()
        {
            for (int i = 0; i < _hitBuffer.Length; i++)
            {
                _hitBuffer[i] = null;
            }
        }

        private int LootinRadius(GameEntity looter)
        {
            return _physicsService
                 .SphereCastNonAlloc(looter.Transform.position, looter.PickupRadius, _layerMask, _hitBuffer);
        }
    }
}