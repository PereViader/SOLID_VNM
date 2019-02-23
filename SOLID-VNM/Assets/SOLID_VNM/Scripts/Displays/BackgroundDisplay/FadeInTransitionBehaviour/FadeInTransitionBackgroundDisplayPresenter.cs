using System;
using UnityEngine;
using Zenject;

namespace SOLID_VNM.Displays.BackgroundDisplay.FadeInTransitionBehaviour
{
    public class FadeInTransitionBackgroundDisplayPresenter : BackgroundDisplayPresenter
    {
        private readonly BackgroundDisplayView _view;
        private readonly Settings _settings;

        private FadeInTransitionBackgroundDisplayModel _model;

        public FadeInTransitionBackgroundDisplayPresenter(FadeInTransitionBackgroundDisplayModel model, BackgroundDisplayView view, Settings settings)
        {
            _view = view;
            _settings = settings;
            _model = model;
        }

        void BackgroundDisplayPresenter.Start()
        {
            _view.CanvasImage.sprite = _model.BackgroundSprite;
            _view.CanvasImage.color = _settings.startingFadeColor;
            SetVisible(true);
        }

        void BackgroundDisplayPresenter.Tick()
        {
            _view.CanvasImage.color = Color.Lerp(_view.CanvasImage.color, Color.white, _model.InterpolationFactor * Time.deltaTime);
        }

        void BackgroundDisplayPresenter.Reset()
        {
            _view.CanvasImage.color = Color.white;
        }

        void BackgroundDisplayPresenter.Hide()
        {
            SetVisible(false);
        }

        private void SetVisible(bool v)
        {
            _view.Canvas.SetActive(true);
        }

        [System.Serializable]
        public class Settings
        {
            public Color startingFadeColor;
        }

        public class Factory : PlaceholderFactory<FadeInTransitionBackgroundDisplayModel, FadeInTransitionBackgroundDisplayPresenter> { }
    }
}