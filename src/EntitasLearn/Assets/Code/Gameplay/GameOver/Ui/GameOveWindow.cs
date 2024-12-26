using Code.Gameplay.Windows;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine.UI;
using Zenject;


namespace Assets.Code.Gameplay.GameOver.Ui
{
    public sealed class GameOveWindow : BaseWindow
    {
        public Button ReturnHomeButton;

        private IGameStateMachine _gameStateMachine;
        private IWindowService _windowService;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, IWindowService windowService)
        {
            Id = WindowId.GameOverWindow;

            _gameStateMachine = gameStateMachine;
            _windowService = windowService;
        }

        protected override void Initialize()
        {
            ReturnHomeButton.onClick.AddListener(ReturnHome);
        }

        private void ReturnHome()
        {
            _windowService.Close(Id);
            _gameStateMachine.Enter<LoadingHomeScreenState>();
        }
    }
}