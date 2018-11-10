using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Displays;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ImageDisplay;

namespace SOLID_VNM.Core.Scenes.DialogueScene
{
    public interface ITextScenePlayer : IScenePlayer<TextSceneDefinition>
    {
    }

    public class TextScenePlayer : ITextScenePlayer
    {
        private readonly ITextDisplay _textDisplay;
        private readonly ISceneContentDialogueTextDisplayContentExtractor _textDisplayContentExtractor;

        private readonly IBackgroundDisplay _backgroundDisplay;
        private readonly ISceneContentDialogueBackgroundDisplayContentExtractor _backgroundDisplayContentExtractor;

        private readonly IImageDisplay _imageDisplay;
        private readonly ISceneContentDialogueImageDisplayContentExtractor _imageDisplayContentExtractor;


        public TextScenePlayer(
            ITextDisplay textDisplay,
            ISceneContentDialogueTextDisplayContentExtractor textDisplayContentExtractor,
            IBackgroundDisplay backgroundDisplay,
            ISceneContentDialogueBackgroundDisplayContentExtractor backgroundDisplayContentExtractor,
            IImageDisplay imageDisplay,
            ISceneContentDialogueImageDisplayContentExtractor imageDisplayContentExtractor)
        {
            _textDisplay = textDisplay;
            _textDisplayContentExtractor = textDisplayContentExtractor;

            _backgroundDisplay = backgroundDisplay;
            _backgroundDisplayContentExtractor = backgroundDisplayContentExtractor;

            _imageDisplay = imageDisplay;
            _imageDisplayContentExtractor = imageDisplayContentExtractor;
        }

        void IScenePlayer<TextSceneDefinition>.Play(TextSceneDefinition textSceneDefinition)
        {
            IDialogueSceneModel dialogueScene = textSceneDefinition.DialogueSceneModel;

            _textDisplay.Display(_textDisplayContentExtractor.Extract(dialogueScene));
            _backgroundDisplay.Display(_backgroundDisplayContentExtractor.Extract(dialogueScene));
            _imageDisplay.Display(_imageDisplayContentExtractor.Extract(dialogueScene));
        }

        void IScenePlayer<TextSceneDefinition>.End()
        {
            _textDisplay.Hide();
            _backgroundDisplay.Hide();
            _imageDisplay.Hide();
        }
    }
}
