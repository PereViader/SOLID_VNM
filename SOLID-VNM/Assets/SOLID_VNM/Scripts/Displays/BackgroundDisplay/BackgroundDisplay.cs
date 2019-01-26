using Zenject;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public interface BackgroundDisplay : Display<BackgroundDisplayContent> { }

    public class ConcreteBackgroundDisplay : BackgroundDisplay, IInitializable
    {
        private readonly BackgroundDisplayView _backgroundDisplayView;

        public ConcreteBackgroundDisplay(BackgroundDisplayView backgroundDisplayView)
        {
            _backgroundDisplayView = backgroundDisplayView;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        void Display<BackgroundDisplayContent>.Display(BackgroundDisplayContent backgroundDisplayContent)
        {
            _backgroundDisplayView.Display(backgroundDisplayContent);
        }

        void Display<BackgroundDisplayContent>.Hide()
        {
            Hide();
        }

        private void Hide()
        {
            _backgroundDisplayView.Hide();
        }
    }
}
