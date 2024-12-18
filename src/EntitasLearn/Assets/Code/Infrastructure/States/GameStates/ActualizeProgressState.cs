using Assets.Code.Meta;
using Assets.Code.Meta.Features.Simulation;
using Assets.Code.Progress.SaveLoad;
using Code.Common.Entity;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Progress.Data;
using Code.Progress.Provider;
using System;
using UnityEngine;


namespace Assets.Code.Infrastructure.States.GameStates
{
    public class ActualizeProgressState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ITimeService _time;
        private readonly IProgressProvider _progressProvider;
        private readonly ISystemFactory _systemFactory;
        private readonly ISaveLoadService _saveLoadService;
        private ActualizationFeature _actualizationFeature;

        private TimeSpan TwoDays = TimeSpan.FromDays(2);

        public ActualizeProgressState(
            IGameStateMachine stateMachine,
            IProgressProvider progressProvider,
            ISystemFactory systemFactory,
            ITimeService time,
            ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _progressProvider = progressProvider;
            _systemFactory = systemFactory;
            _time = time;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            _actualizationFeature = _systemFactory.Create<ActualizationFeature>();
            ActualizeProgress(_progressProvider.ProgressData);
            _stateMachine.Enter<LoadingHomeScreenState>();
        }

        private void ActualizeProgress(ProgressData data)
        {
            _actualizationFeature.Initialize();
            DateTime until = GetLimitedUntilTime(data);

            Debug.Log($"Actualizing {(until - data.LastSimulationTickTime).TotalSeconds} seconds");

            while (data.LastSimulationTickTime < until)
            {
                var tick = CreateMetaEntity
                      .Empty()
                      .AddTick(MetaConstants.SimulationTickSeconds);

                _actualizationFeature.Execute();
                _actualizationFeature.Cleanup();

                tick.Destroy();
            }

            data.LastSimulationTickTime = _time.UtcNow;
            _saveLoadService.SaveProgress();
        }

        private DateTime GetLimitedUntilTime(ProgressData data)
        {
            if (_time.UtcNow - data.LastSimulationTickTime < TwoDays)
                return _time.UtcNow;

            return data.LastSimulationTickTime + TwoDays;
        }

        public void Exit()
        {
            _actualizationFeature.Cleanup();
            _actualizationFeature.TearDown();
            _actualizationFeature = null;
        }
    }
}
