using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Displays;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ImageDisplay;

namespace SOLID_VNM.Core.Scenes.TextScene
{
    public interface ITextScenePlayer : IScenePlayer<TextSceneDefinition>
    {
    }

    public class TextScenePlayer : ITextScenePlayer
    {
        readonly private ITextDisplay _textDisplay;
        readonly private ISceneContentDialogueTextDisplayContentExtractor _textDisplayContentExtractor;

        readonly private IBackgroundDisplay _backgroundDisplay;
        readonly private ISceneContentDialogueBackgroundDisplayContentExtractor _backgroundDisplayContentExtractor;

        readonly private IImageDisplay _imageDisplay;
        readonly private ISceneContentDialogueImageDisplayContentExtractor _imageDisplayContentExtractor;


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
            SceneContentDialogue sceneContent = textSceneDefinition.SceneContentDialogue;

            _textDisplay.Display(_textDisplayContentExtractor.Extract(sceneContent));
            _backgroundDisplay.Display(_backgroundDisplayContentExtractor.Extract(sceneContent));
            _imageDisplay.Display(_imageDisplayContentExtractor.Extract(sceneContent));
        }

        void IScenePlayer<TextSceneDefinition>.End()
        {
            _textDisplay.Hide();
            _backgroundDisplay.Hide();
            _imageDisplay.Hide();
        }
    }
}
