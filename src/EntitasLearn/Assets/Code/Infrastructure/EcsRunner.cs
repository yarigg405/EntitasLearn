using Assets.Code.Gameplay;
using Code.Infrastructure.Systems;
using UnityEngine;
using Zenject;


namespace Assets.Code.Infrastructure
{
    internal sealed class EcsRunner : MonoBehaviour
    {        
        [Inject] private readonly ISystemFactory _systemFactory;

        private BattleFeature _battleFeature;

        private void Start()
        {
            _battleFeature = _systemFactory.Create<BattleFeature>();
            _battleFeature.Initialize();
        }

        private void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        private void OnDestroy()
        {
            _battleFeature.TearDown();
        }
    }
}
