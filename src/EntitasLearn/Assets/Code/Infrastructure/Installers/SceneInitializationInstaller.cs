using System.Collections.Generic;
using UnityEngine;
using Zenject;



namespace Code.Infrastructure.Installers
{
    internal sealed class SceneInitializationInstaller : MonoInstaller
    {
        public List<MonoBehaviour> Initializers;

        public override void InstallBindings()
        {
            foreach (MonoBehaviour initializer in Initializers)
            {
                Container.BindInterfacesTo(initializer.GetType()).FromInstance(initializer).AsSingle();
            }
        }
    }
}