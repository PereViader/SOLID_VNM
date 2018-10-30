namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public interface IBackgroundDisplay : IDisplay<BackgroundDisplayContent> { }

    public class BackgroundDisplayController : IBackgroundDisplay
    {
        private readonly BackgroundDisplayView _backgroundDisplayView;

        public BackgroundDisplayController(BackgroundDisplayView backgroundDisplayView)
        {
            _backgroundDisplayView = backgroundDisplayView;
        }

        public void Hide()
        {
            _backgroundDisplayView.Hide();
        }

        public void Display(BackgroundDisplayContent backgroundDisplayContent)
        {
            _backgroundDisplayView.Display(backgroundDisplayContent);
        }
    }
}
