using Zenject;

using UnityEngine;

namespace SOLID_VNM.Displays.BackgroundDisplay.NoTransitionBehaviour
{
    public class NoTransitionBackgroundDisplayModel : BackgroundDisplayModel
    {
        private Sprite _backgroundSprite;

        public Sprite BackgroundSprite { get { return _backgroundSprite; } }

        public NoTransitionBackgroundDisplayModel(Sprite backgroundSprite)
        {
            _backgroundSprite = backgroundSprite;
        }

        void BackgroundDisplayModel.Visit(BackgroundDisplayModelVisitor visitor)
        {
            visitor.Accept(this);
        }

        public class Factory : PlaceholderFactory<Sprite, NoTransitionBackgroundDisplayModel> { }
    }
}