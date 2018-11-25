using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ActorDisplay;

namespace SOLID_VNM.Core.Scenes.DialogueScene
{
    public interface IDialogueScenePlayer : IScenePlayer<IDialogueScene> { }

    public class ConcreteDialogueScenePlayer : IDialogueScenePlayer
    {
        private readonly ITextDisplay _textDisplay;
        private readonly IDialogueSceneModelTextDisplayContentExtractor _textDisplayContentExtractor;

        private readonly IBackgroundDisplay _backgroundDisplay;
        private readonly IDialogueSceneModelBackgroundDisplayContentExtractor _backgroundDisplayContentExtractor;

        private readonly IActorDisplay _actorDisplay;
        private readonly IDialogueSceneModelActorDisplayContentExtractor _actorDisplayContentExtractor;


        public ConcreteDialogueScenePlayer(
            ITextDisplay textDisplay,
            IDialogueSceneModelTextDisplayContentExtractor textDisplayContentExtractor,
            IBackgroundDisplay backgroundDisplay,
            IDialogueSceneModelBackgroundDisplayContentExtractor backgroundDisplayContentExtractor,
        IActorDisplay actorDisplay,
        IDialogueSceneModelActorDisplayContentExtractor actorDisplayContentExtractor)
        {
            _textDisplay = textDisplay;
            _textDisplayContentExtractor = textDisplayContentExtractor;

            _backgroundDisplay = backgroundDisplay;
            _backgroundDisplayContentExtractor = backgroundDisplayContentExtractor;

            _actorDisplay = actorDisplay;
            _actorDisplayContentExtractor = actorDisplayContentExtractor;
        }

        void IScenePlayer<IDialogueScene>.Play(IDialogueScene dialogueScene)
        {
            IDialogueSceneModel dialogueSceneModel = dialogueScene.DialogueSceneModel;

            _textDisplay.Display(_textDisplayContentExtractor.Extract(dialogueSceneModel));
            _backgroundDisplay.Display(_backgroundDisplayContentExtractor.Extract(dialogueSceneModel));
            _actorDisplay.Display(_actorDisplayContentExtractor.Extract(dialogueSceneModel));
        }

        void IScenePlayer<IDialogueScene>.End()
        {
            _textDisplay.Hide();
            _backgroundDisplay.Hide();
            _actorDisplay.Hide();
        }
    }
}
