using UnityEngine;
using UnityEngine.UI;

using Zenject;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public interface BackgroundDisplayView
    {
        GameObject BackgroundDisplay { get; }
        Image FrontBackground { get; }
        Image BackBackground { get; }

        void SwapBackgrounds();
    }

    public class BackgroundDisplayViewImp : BackgroundDisplayView, IInitializable
    {
        private readonly BackgroundDisplayViewMB _backgroundDisplayViewMB;

        private Image _frontBackground;
        private Image _backBackground;

        Image BackgroundDisplayView.FrontBackground { get { return _frontBackground; } }
        Image BackgroundDisplayView.BackBackground { get { return _backBackground; } }

        GameObject BackgroundDisplayView.BackgroundDisplay { get { return _backgroundDisplayViewMB.Canvas; } }

        public BackgroundDisplayViewImp(BackgroundDisplayViewMB backgroundDisplayViewMB)
        {
            _backgroundDisplayViewMB = backgroundDisplayViewMB;
        }

        void IInitializable.Initialize()
        {
            _frontBackground = _backgroundDisplayViewMB.StartingFrontBackground;
            _backBackground = _backgroundDisplayViewMB.StartingBackBackground;
        }

        void BackgroundDisplayView.SwapBackgrounds()
        {
            Image tmp = _frontBackground;
            _frontBackground = _backBackground;
            _backBackground = tmp;

            //The last UI element is rendered on top of all the rest 
            _frontBackground.gameObject.transform.SetAsLastSibling();
        }
    }
}