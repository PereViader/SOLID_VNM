using Zenject;

namespace SOLID_VNM.Displays.BackgroundDisplay.NoTransitionBehaviour
{
    public class NoTransitionBackgroundDisplayPresenter : BackgroundDisplayPresenter
    {
        private readonly BackgroundDisplayView _backgroundDisplayView;

        private NoTransitionBackgroundDisplayModel _model;

        public NoTransitionBackgroundDisplayPresenter(NoTransitionBackgroundDisplayModel model, BackgroundDisplayView backgroundDisplayView)
        {
            _backgroundDisplayView = backgroundDisplayView;
            _model = model;
        }

        void BackgroundDisplayPresenter.Start()
        {
            _backgroundDisplayView.FrontBackground.sprite = _model.BackgroundSprite;
            SetVisible(true);
        }

        void BackgroundDisplayPresenter.Tick()
        {
        }

        void BackgroundDisplayPresenter.End()
        {
        }

        void BackgroundDisplayPresenter.Hide()
        {
            SetVisible(false);
        }

        private void SetVisible(bool status)
        {
            _backgroundDisplayView.BackgroundDisplay.SetActive(status);
        }

        public class Factory : PlaceholderFactory<NoTransitionBackgroundDisplayModel, NoTransitionBackgroundDisplayPresenter> { }
    }
}