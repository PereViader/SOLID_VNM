using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Core.Scenes.TextScene;
using SOLID_VNM.Displays;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ChoiceDisplay;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.ImageDisplay;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public interface IChoiceScenePlayer : IScenePlayer<ChoiceSceneDefinition>
    {
    }

    public class ChoiceScenePlayer : IChoiceScenePlayer
    {
        readonly private IChoiceDisplay _choiceDisplay;
        readonly private ISceneContentChoiceChoiceDisplayContentExtractor _choiceDisplayContentExtractor;

        readonly private IBackgroundDisplay _backgroundDisplay;
        readonly private ISceneContentChoiceBackgroundDisplayContentExtractor _backgroundDisplayContentExtractor;

        public ChoiceScenePlayer(
            IChoiceDisplay choiceDisplay,
            ISceneContentChoiceChoiceDisplayContentExtractor choiceDisplayContentExtractor,
            IBackgroundDisplay backgroundDisplay,
            ISceneContentChoiceBackgroundDisplayContentExtractor backgroundDisplayContentExtractor)
        {
            _choiceDisplay = choiceDisplay;
            _choiceDisplayContentExtractor = choiceDisplayContentExtractor;

            _backgroundDisplay = backgroundDisplay;
            _backgroundDisplayContentExtractor = backgroundDisplayContentExtractor;
        }

        void IScenePlayer<ChoiceSceneDefinition>.Play(ChoiceSceneDefinition sceneDefinition)
        {
            SceneContentChoice sceneContent = sceneDefinition.SceneContentChoice;

            _choiceDisplay.Display(_choiceDisplayContentExtractor.Extract(sceneContent));
            _backgroundDisplay.Display(_backgroundDisplayContentExtractor.Extract(sceneContent));
        }

        void IScenePlayer<ChoiceSceneDefinition>.End()
        {
            _choiceDisplay.Hide();
            _backgroundDisplay.Hide();
        }
    }
}
