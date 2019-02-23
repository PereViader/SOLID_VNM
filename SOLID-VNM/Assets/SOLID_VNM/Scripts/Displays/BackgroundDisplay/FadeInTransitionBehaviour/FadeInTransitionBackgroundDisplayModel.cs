using UnityEngine;

using Zenject;

namespace SOLID_VNM.Displays.BackgroundDisplay.FadeInTransitionBehaviour
{
    public class FadeInTransitionBackgroundDisplayModel : BackgroundDisplayModel
    {
        private Sprite _backgroundSprite;
        private float _interpolationFactor;

        public Sprite BackgroundSprite { get { return _backgroundSprite; } }
        public float InterpolationFactor { get { return _interpolationFactor; } }

        public FadeInTransitionBackgroundDisplayModel(Sprite backgroundSprite, float interpolationFactor)
        {
            _backgroundSprite = backgroundSprite;
            _interpolationFactor = interpolationFactor;
        }

        void BackgroundDisplayModel.Visit(BackgroundDisplayModelVisitor visitor)
        {
            visitor.Accept(this);
        }

        public class Factory : PlaceholderFactory<Sprite, float, FadeInTransitionBackgroundDisplayModel> { }
    }
}