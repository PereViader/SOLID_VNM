using Zenject;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public interface IBackgroundDisplay : IDisplay<BackgroundDisplayContent> { }

    public class ConcreteBackgroundDisplay : IBackgroundDisplay, IInitializable
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

        void IDisplay<BackgroundDisplayContent>.Display(BackgroundDisplayContent backgroundDisplayContent)
        {
            _backgroundDisplayView.Display(backgroundDisplayContent);
        }

        void IDisplay<BackgroundDisplayContent>.Hide()
        {
            Hide();
        }

        private void Hide()
        {
            _backgroundDisplayView.Hide();
        }
    }
}
