using Code.Gameplay.Cameras.Provider;
using Entitas;
using UnityEngine;


namespace Assets.Code.Gameplay.Cameras.Systems
{
    internal sealed class CameraFollowHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly ICameraProvider _cameraProvider;

        private readonly Vector3 _followOffset = new Vector3(0.09f, 9.4f, -6.8f);

        public CameraFollowHeroSystem(GameContext context, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _heroes = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.Transform));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var hero in _heroes)
            {
                _cameraProvider.MainCamera.transform.position = hero.Transform.position + _followOffset;
            }
        }
    }
}
