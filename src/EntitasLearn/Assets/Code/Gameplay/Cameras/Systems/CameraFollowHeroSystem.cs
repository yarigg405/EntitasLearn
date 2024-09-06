using Code.Common.Extensions;
using Code.Gameplay.Cameras.Provider;
using Entitas;


namespace Assets.Code.Gameplay.Cameras.Systems
{
    internal sealed class CameraFollowHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly ICameraProvider _cameraProvider;

        public CameraFollowHeroSystem(GameContext context, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _heroes = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.WorldPosition));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var hero in _heroes)
            {
                _cameraProvider.MainCamera.transform.SetWorldXY(hero.WorldPosition.x, hero.WorldPosition.y);
            }
        }
    }
}
