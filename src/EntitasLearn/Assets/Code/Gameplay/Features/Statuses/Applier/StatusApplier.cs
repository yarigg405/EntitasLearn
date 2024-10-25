using Assets.Code.Common.EntityIndicies;
using Assets.Code.Gameplay.Features.Statuses.Factory;
using Code.Common.Extensions;
using System.Linq;


namespace Assets.Code.Gameplay.Features.Statuses.Applier
{
    internal sealed class StatusApplier
    {
        private readonly GameContext _game;
        private readonly StatusFactory _statusFactory;

        public StatusApplier(GameContext game, StatusFactory statusFacory)
        {
            _game = game;
            _statusFactory = statusFacory;
        }

        public GameEntity ApplyStatus(StatusSetup setup, int producerId, int targetId)
        {
            var status = _game.TargetStatusesOfType(setup.StatusTypeId, targetId).FirstOrDefault();
            if (status != null)
            {
                return status.ReplaceTimeLeft(setup.Duration);
            }

            else
            {
                return _statusFactory.CreateStatus(setup, producerId, targetId)
                    .With(x => x.isApplied = true);
            }
        }
    }
}
