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
            ApplyContents();
            SetVisible(true);
        }

        void BackgroundDisplayPresenter.Tick()
        {
        }

        void BackgroundDisplayPresenter.Reset()
        {
            _backgroundDisplayView.CanvasImage.sprite = null;
        }

        void BackgroundDisplayPresenter.Hide()
        {
            SetVisible(false);
        }

        private void ApplyContents()
        {
            _backgroundDisplayView.CanvasImage.sprite = _model.BackgroundSprite;
        }

        private void SetVisible(bool status)
        {
            _backgroundDisplayView.Canvas.SetActive(status);
        }

        public class Factory : PlaceholderFactory<NoTransitionBackgroundDisplayModel, NoTransitionBackgroundDisplayPresenter> { }
    }
}