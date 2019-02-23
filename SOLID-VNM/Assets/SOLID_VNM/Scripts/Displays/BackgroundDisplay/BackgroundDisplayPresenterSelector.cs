using System;
using SOLID_VNM.Displays.BackgroundDisplay.FadeInTransitionBehaviour;
using SOLID_VNM.Displays.BackgroundDisplay.NoTransitionBehaviour;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public interface BackgroundDisplayPresenterSelectorFactory
    {
        BackgroundDisplayPresenter Create(BackgroundDisplayModel model);
    }

    public class BackgroundDisplayPresenterSelectorFactoryImp : BackgroundDisplayPresenterSelectorFactory, BackgroundDisplayModelVisitor
    {
        private readonly NoTransitionBackgroundDisplayPresenter.Factory _noTransitionBackgroundDisplayPresenterFactory;
        private readonly FadeInTransitionBackgroundDisplayPresenter.Factory _fadeInTransitionBackgroundDisplayPresenterFactory;


        private BackgroundDisplayPresenter _presenter;

        public BackgroundDisplayPresenterSelectorFactoryImp(NoTransitionBackgroundDisplayPresenter.Factory noTransitionBackgroundDisplayPresenterFactory)
        {
            _noTransitionBackgroundDisplayPresenterFactory = noTransitionBackgroundDisplayPresenterFactory;
        }

        BackgroundDisplayPresenter BackgroundDisplayPresenterSelectorFactory.Create(BackgroundDisplayModel model)
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