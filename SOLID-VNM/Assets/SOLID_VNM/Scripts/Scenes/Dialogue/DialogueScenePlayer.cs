using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ActorDisplay;

namespace SOLID_VNM.Scenes.Dialogue
{
    public interface DialogueScenePlayer : ScenePlayer<DialogueScene> { }

    public class ConcreteDialogueScenePlayer : DialogueScenePlayer
    {
        private readonly TextDisplay _textDisplay;
        private readonly DialogueSceneModelTextDisplayContentMapper _textDisplayContentExtractor;

        private readonly BackgroundDisplay _backgroundDisplay;
        private readonly DialogueSceneModelBackgroundDisplayContentMapper _backgroundDisplayContentExtractor;

        private readonly ActorDisplay _actorDisplay;
        private readonly DialogueSceneModelActorDisplayContentMapper _actorDisplayContentExtractor;


        public ConcreteDialogueScenePlayer(
            TextDisplay textDisplay,
            DialogueSceneModelTextDisplayContentMapper textDisplayContentExtractor,
            BackgroundDisplay backgroundDisplay,
            DialogueSceneModelBackgroundDisplayContentMapper backgroundDisplayContentExtractor,
            ActorDisplay actorDisplay,
            DialogueSceneModelActorDisplayContentMapper actorDisplayContentExtractor)
        {
            _textDisplay = textDisplay;
            _textDisplayContentExtractor = textDisplayContentExtractor;

            _backgroundDisplay = backgroundDisplay;
            _backgroundDisplayContentExtractor = backgroundDisplayContentExtractor;

            _actorDisplay = actorDisplay;
            _actorDisplayContentExtractor = actorDisplayContentExtractor;
        }

        void ScenePlayer<DialogueScene>.Play(DialogueScene dialogueScene)
        {
            DialogueSceneModel dialogueSceneModel = dialogueScene.DialogueSceneModel;

            _textDisplay.Display(_textDisplayContentExtractor.From(dialogueSceneModel));
            _backgroundDisplay.Display(_backgroundDisplayContentExtractor.From(dialogueSceneModel));
            _actorDisplay.Display(_actorDisplayContentExtractor.From(dialogueSceneModel));
        }

        void ScenePlayer<DialogueScene>.End()
        {
            _textDisplay.Stop();
            _backgroundDisplay.Stop();
            _actorDisplay.Stop();
        }
    }
}
