using Zenject;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public interface BackgroundDisplay : Display<BackgroundDisplayContent> { }

    public class BackgroundDisplayImp : BackgroundDisplay, IInitializable
    {
        private readonly BackgroundDisplayBehaviour _backgroundDisplayBehaviour;

        public BackgroundDisplayImp(BackgroundDisplayBehaviour backgroundDisplayBehaviour)
        {
            _backgroundDisplayBehaviour = backgroundDisplayBehaviour;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        void Display<BackgroundDisplayContent>.Display(BackgroundDisplayContent backgroundDisplayContent)
        {
            _backgroundDisplayBehaviour.Display(backgroundDisplayContent);
            _backgroundDisplayBehaviour.Show();
        }

        void Display<BackgroundDisplayContent>.Hide()
        {
            Hide();
        }

        private void Hide()
        {
            _backgroundDisplayBehaviour.Hide();
        }
    }
}
