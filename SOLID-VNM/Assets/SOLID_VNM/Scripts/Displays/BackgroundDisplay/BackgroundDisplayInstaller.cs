using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public class BackgroundDisplayInstaller : MonoInstaller
    {

        [SerializeField]
        private BackgroundDisplayView _backgroundDisplayView;

        public override void InstallBindings()
        {
            Container.BindInstance(_backgroundDisplayView);

            Container.Bind<IBackgroundDisplay>().To<BackgroundDisplayController>().AsSingle().NonLazy();

            Container.BindFactory<Sprite, BackgroundDisplayContent, BackgroundDisplayContent.Factory>();
        }
    }
}
