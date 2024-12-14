using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;


namespace Assets.Code.Infrastructure.Installers
{
    public class UiInitializer : MonoBehaviour, IInitializable
    {
        public RectTransform UiRoot;
        private IWindowFactory _windowFactory;

        [Inject]
        private void Construct(IWindowFactory windowFactory)
        {
            _windowFactory = windowFactory;
        }

        public void Initialize()
        {
            _windowFactory.SetUIRoot(UiRoot);
        }
    }
}
