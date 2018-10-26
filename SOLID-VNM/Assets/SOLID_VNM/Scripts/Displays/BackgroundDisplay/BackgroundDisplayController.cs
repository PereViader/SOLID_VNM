namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public class BackgroundDisplayController : IDisplay
    {
        readonly private BackgroundDisplayContentExtractor _backgroundDisplayContentExtractor;
        readonly private BackgroundDisplayView _backgroundDisplayView;

        public BackgroundDisplayController(BackgroundDisplayContentExtractor backgroundDisplayContentExtractor, BackgroundDisplayView backgroundDisplayView)
        {
            _backgroundDisplayContentExtractor = backgroundDisplayContentExtractor;
            _backgroundDisplayView = backgroundDisplayView;
        }

        public void Hide()
        {
            _backgroundDisplayView.Hide();
        }

        public void Display(SceneContent sceneContent)
        {
            using (BackgroundDisplayContent backgroundDisplayContent = _backgroundDisplayContentExtractor.Extract(sceneContent))
            {
                _backgroundDisplayView.Display(backgroundDisplayContent);
            }
        }
    }
}
