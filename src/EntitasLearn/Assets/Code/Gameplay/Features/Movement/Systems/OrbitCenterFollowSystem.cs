using Entitas;


namespace Assets.Code.Gameplay.Features.Movement.Systems
{
    internal sealed class OrbitCenterFollowSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _orbitCenters;
        private readonly IGroup<GameEntity> _targets;

        internal OrbitCenterFollowSystem(GameContext game)
        {
            _orbitCenters = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.OrbitCenterPosition,
                GameMatcher.OrbitCenterFollowTarget
            ));

            _targets = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Id,
                GameMatcher.Transform));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var orbitCenter in _orbitCenters)
                foreach (var target in _targets)
                {
                    if (orbitCenter.OrbitCenterFollowTarget == target.Id)
                    {
                        orbitCenter.ReplaceOrbitCenterPosition(target.Transform.position);
                    }
                }
        }
    }
}