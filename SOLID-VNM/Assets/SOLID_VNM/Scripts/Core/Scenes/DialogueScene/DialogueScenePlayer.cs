using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ImageDisplay;

namespace SOLID_VNM.Core.Scenes.DialogueScene
{
    public interface IDialogueScenePlayer : IScenePlayer<IDialogueScene> { }

    public class ConcreteDialogueScenePlayer : IDialogueScenePlayer
    {
        private readonly ITextDisplay _textDisplay;
        private readonly IDialogueSceneModelTextDisplayContentExtractor _textDisplayContentExtractor;

        private readonly IBackgroundDisplay _backgroundDisplay;
        private readonly IDialogueSceneModelBackgroundDisplayContentExtractor _backgroundDisplayContentExtractor;

        private readonly IImageDisplay _imageDisplay;
        private readonly IDialogueSceneModelImageDisplayContentExtractor _imageDisplayContentExtractor;


        public ConcreteDialogueScenePlayer(
            ITextDisplay textDisplay,
            IDialogueSceneModelTextDisplayContentExtractor textDisplayContentExtractor,
            IBackgroundDisplay backgroundDisplay,
            IDialogueSceneModelBackgroundDisplayContentExtractor backgroundDisplayContentExtractor,
            IImageDisplay imageDisplay,
            IDialogueSceneModelImageDisplayContentExtractor imageDisplayContentExtractor)
        {
            _textDisplay = textDisplay;
            _textDisplayContentExtractor = textDisplayContentExtractor;

            _backgroundDisplay = backgroundDisplay;
            _backgroundDisplayContentExtractor = backgroundDisplayContentExtractor;

            _imageDisplay = imageDisplay;
            _imageDisplayContentExtractor = imageDisplayContentExtractor;
        }

        void IScenePlayer<IDialogueScene>.Play(IDialogueScene dialogueScene)
        {
            IDialogueSceneModel dialogueSceneModel = dialogueScene.DialogueSceneModel;

            _textDisplay.Display(_textDisplayContentExtractor.Extract(dialogueSceneModel));
            _backgroundDisplay.Display(_backgroundDisplayContentExtractor.Extract(dialogueSceneModel));
            _imageDisplay.Display(_imageDisplayContentExtractor.Extract(dialogueSceneModel));
        }

        void IScenePlayer<IDialogueScene>.End()
        {
            _textDisplay.Hide();
            _backgroundDisplay.Hide();
            _imageDisplay.Hide();
        }
    }
}
