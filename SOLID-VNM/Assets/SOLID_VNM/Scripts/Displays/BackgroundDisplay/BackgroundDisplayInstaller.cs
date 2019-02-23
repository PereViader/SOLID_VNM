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
        private BackgroundDisplayViewMB _backgroundDisplayViewMB;

        public override void InstallBindings()
        {
            InstallMain();
            InstallBackgroundView();
            InstallNoTransitionBackgroundBehaviour();
            InstallFadeInTransitionBackgroundBehavuiour();
        }

        private void InstallMain()
        {
            Container.BindInterfacesTo<BackgroundDisplayImp>().AsSingle();
            Container.BindFactory<BackgroundDisplayModel, BackgroundDisplayPresenter, BackgroundDisplayPresenterFactory>().FromFactory<BackgroundDisplayPresenterFactoryImp>();
        }

        private void InstallBackgroundView()
        {
            Container.BindInterfacesTo<BackgroundDisplayViewImp>().AsSingle();
            Container.BindInstance(_backgroundDisplayViewMB);
        }

        private void InstallNoTransitionBackgroundBehaviour()
        {
            Container.BindFactory<Sprite, NoTransitionBackgroundDisplayModel, NoTransitionBackgroundDisplayModel.Factory>();
            Container.BindFactory<NoTransitionBackgroundDisplayModel, NoTransitionBackgroundDisplayPresenter, NoTransitionBackgroundDisplayPresenter.Factory>();
        }

        private void InstallFadeInTransitionBackgroundBehavuiour()
        {
            Container.BindFactory<Sprite, float, FadeInTransitionBackgroundDisplayModel, FadeInTransitionBackgroundDisplayModel.Factory>();
            Container.BindFactory<FadeInTransitionBackgroundDisplayModel, FadeInTransitionBackgroundDisplayPresenter, FadeInTransitionBackgroundDisplayPresenter.Factory>();
        }
    }
}
