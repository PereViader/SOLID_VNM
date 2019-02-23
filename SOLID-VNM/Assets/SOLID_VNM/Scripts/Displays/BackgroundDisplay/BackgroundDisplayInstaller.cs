using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using SOLID_VNM.Displays.BackgroundDisplay.NoTransitionBehaviour;
using SOLID_VNM.Displays.BackgroundDisplay.FadeInTransitionBehaviour;


namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public class BackgroundDisplayInstaller : MonoInstaller
    {

        [SerializeField]
        private BackgroundDisplayView _backgroundDisplayView;

        public override void InstallBindings()
        {
            Container.BindInstance(_backgroundDisplayView);

            Container.BindInterfacesTo<BackgroundDisplayImp>().AsSingle();

            Container.Bind<BackgroundDisplayPresenterSelectorFactory>().To<BackgroundDisplayPresenterSelectorFactoryImp>().AsSingle();

            //No transition
            Container.BindFactory<Sprite, NoTransitionBackgroundDisplayModel, NoTransitionBackgroundDisplayModel.Factory>();
            Container.BindFactory<NoTransitionBackgroundDisplayModel, NoTransitionBackgroundDisplayPresenter, NoTransitionBackgroundDisplayPresenter.Factory>();


            //Fade in transition
            Container.BindFactory<Sprite, float, FadeInTransitionBackgroundDisplayModel, FadeInTransitionBackgroundDisplayModel.Factory>();
            Container.BindFactory<FadeInTransitionBackgroundDisplayModel, FadeInTransitionBackgroundDisplayPresenter, FadeInTransitionBackgroundDisplayPresenter.Factory>();
        }
    }
}
