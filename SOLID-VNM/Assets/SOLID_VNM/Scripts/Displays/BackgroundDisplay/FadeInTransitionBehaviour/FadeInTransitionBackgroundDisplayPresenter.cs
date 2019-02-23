using System;
using UnityEngine;
using Zenject;

namespace SOLID_VNM.Displays.BackgroundDisplay.FadeInTransitionBehaviour
{
    public class FadeInTransitionBackgroundDisplayPresenter : BackgroundDisplayPresenter
    {
        private readonly BackgroundDisplayView _view;

        private FadeInTransitionBackgroundDisplayModel _model;

        public FadeInTransitionBackgroundDisplayPresenter(FadeInTransitionBackgroundDisplayModel model, BackgroundDisplayView view)
        {
            _view = view;
            _model = model;
        }

        void BackgroundDisplayPresenter.Start()
        {
            _view.SwapBackgrounds();
            _view.FrontBackground.sprite = _model.BackgroundSprite;
            _view.FrontBackground.color = new Color(1, 1, 1, 0);
            SetVisible(true);
        }

        void BackgroundDisplayPresenter.Tick()
        {
            _view.FrontBackground.color = Color.Lerp(_view.FrontBackground.color, Color.white, _model.InterpolationFactor * Time.deltaTime);
        }

        void BackgroundDisplayPresenter.End()
        {
            _view.FrontBackground.color = Color.white;
            _view.BackBackground.sprite = null;
        }

        void BackgroundDisplayPresenter.Hide()
        {
            SetVisible(false);
        }

        private void SetVisible(bool status)
        {
            _view.BackgroundDisplay.SetActive(status);
        }

        public class Factory : PlaceholderFactory<FadeInTransitionBackgroundDisplayModel, FadeInTransitionBackgroundDisplayPresenter> { }
    }
}