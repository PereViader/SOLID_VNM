namespace SOLID_VNM.Displays.TextDisplay
{
    public interface TextDisplayBehaviour
    {
        void Display(TextDisplayContent content);
        void Show();
        void Hide();
    }

    public class TextDisplayBehaviourImp : TextDisplayBehaviour
    {
        private readonly TextDisplayView _textDisplayView;

        public TextDisplayBehaviourImp(TextDisplayView textDisplayView)
        {
            _textDisplayView = textDisplayView;
        }

        public void Display(TextDisplayContent content)
        {
            _textDisplayView.ContentText.text = content.Text;
            _textDisplayView.ActorText.text = content.ActorName;
        }

        public void Hide()
        {
            _textDisplayView.Canvas.SetActive(false);
        }

        public void Show()
        {
            _textDisplayView.Canvas.SetActive(true);
        }
    }
}