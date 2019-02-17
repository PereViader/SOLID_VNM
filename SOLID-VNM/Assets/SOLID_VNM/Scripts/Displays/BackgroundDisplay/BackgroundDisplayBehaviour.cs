namespace SOLID_VNM.Displays.BackgroundDisplay
{

    public interface BackgroundDisplayBehaviour
    {
        void Display(BackgroundDisplayContent content);
        void Show();
        void Hide();
    }

    public class BackgroundDisplayBehaviourImp : BackgroundDisplayBehaviour
    {
        private readonly BackgroundDisplayView _backgroundDisplayView;

        public BackgroundDisplayBehaviourImp(BackgroundDisplayView backgroundDisplayView)
        {
            _backgroundDisplayView = backgroundDisplayView;
        }

        void BackgroundDisplayBehaviour.Display(BackgroundDisplayContent content)
        {
            _backgroundDisplayView.CanvasImage.sprite = content.BackgroundSprite;
        }

        void BackgroundDisplayBehaviour.Show()
        {
            _backgroundDisplayView.Canvas.SetActive(true);
        }

        void BackgroundDisplayBehaviour.Hide()
        {
            _backgroundDisplayView.Canvas.SetActive(false);
        }
    }
}