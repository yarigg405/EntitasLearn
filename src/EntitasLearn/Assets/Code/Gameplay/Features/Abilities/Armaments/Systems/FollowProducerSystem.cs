using Entitas;


namespace Assets.Code.Gameplay.Features.Abilities.Armaments.Systems
{
    internal sealed class FollowProducerSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _followers;
        private readonly IGroup<GameEntity> _producers;

        internal FollowProducerSystem(GameContext game)
        {
            _followers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.FollowingProducer,
                GameMatcher.Transform,
                GameMatcher.ProducerId
            ));

            _producers = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Id,
                GameMatcher.Transform
                ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var follower in _followers)
                foreach (var producer in _producers)
                {

                    if (follower.ProducerId == producer.Id)
                        follower.Transform.position = producer.Transform.position;
                }
        }
    }
}