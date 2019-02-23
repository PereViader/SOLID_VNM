using System;
using Zenject;

using SOLID_VNM.Displays.BackgroundDisplay.FadeInTransitionBehaviour;
using SOLID_VNM.Displays.BackgroundDisplay.NoTransitionBehaviour;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public interface BackgroundDisplayPresenter
    {
        void Start();
        void Tick();
        void End();
        void Hide();
    }

    public class BackgroundDisplayPresenterFactory : PlaceholderFactory<BackgroundDisplayModel, BackgroundDisplayPresenter>
    {
    }

    public class BackgroundDisplayPresenterFactoryImp : IFactory<BackgroundDisplayModel, BackgroundDisplayPresenter>, BackgroundDisplayModelVisitor
    {
        private readonly NoTransitionBackgroundDisplayPresenter.Factory _noTransitionBackgroundDisplayPresenterFactory;
        private readonly FadeInTransitionBackgroundDisplayPresenter.Factory _fadeInTransitionBackgroundDisplayPresenterFactory;


        private BackgroundDisplayPresenter _presenter;

        public BackgroundDisplayPresenterFactoryImp(NoTransitionBackgroundDisplayPresenter.Factory noTransitionBackgroundDisplayPresenterFactory, FadeInTransitionBackgroundDisplayPresenter.Factory fadeInTransitionBackgroundDisplayPresenterFactory)
        {
            _noTransitionBackgroundDisplayPresenterFactory = noTransitionBackgroundDisplayPresenterFactory;
            _fadeInTransitionBackgroundDisplayPresenterFactory = fadeInTransitionBackgroundDisplayPresenterFactory;
        }

        BackgroundDisplayPresenter IFactory<BackgroundDisplayModel, BackgroundDisplayPresenter>.Create(BackgroundDisplayModel model)
        {
            BuildPresenter(model);
            return _presenter;
        }

        private void BuildPresenter(BackgroundDisplayModel model)
        {
            model.Visit(this);
        }

        void BackgroundDisplayModelVisitor.Accept(NoTransitionBackgroundDisplayModel model)
        {
            _presenter = _noTransitionBackgroundDisplayPresenterFactory.Create(model);
        }

        void BackgroundDisplayModelVisitor.Accept(FadeInTransitionBackgroundDisplayModel model)
        {
            _presenter = _fadeInTransitionBackgroundDisplayPresenterFactory.Create(model);
        }
    }
}