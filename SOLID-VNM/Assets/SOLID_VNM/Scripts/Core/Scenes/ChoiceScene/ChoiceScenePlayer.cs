using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Core.Scenes.DialogueScene;
using SOLID_VNM.Displays;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ChoiceDisplay;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.ImageDisplay;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public interface IChoiceScenePlayer : IScenePlayer<IChoiceScene> { }

    public class ConcreteChoiceScenePlayer : IChoiceScenePlayer
    {
        private readonly IChoiceDisplay _choiceDisplay;
        private readonly IChoiceScenModelChoiceChoiceDisplayContentExtractor _choiceDisplayContentExtractor;

        private readonly IBackgroundDisplay _backgroundDisplay;
        private readonly IChoiceSceneModelBackgroundDisplayContentExtractor _backgroundDisplayContentExtractor;

        public ConcreteChoiceScenePlayer(
            IChoiceDisplay choiceDisplay,
            IChoiceScenModelChoiceChoiceDisplayContentExtractor choiceDisplayContentExtractor,
            IBackgroundDisplay backgroundDisplay,
            IChoiceSceneModelBackgroundDisplayContentExtractor backgroundDisplayContentExtractor)
        {
            _choiceDisplay = choiceDisplay;
            _choiceDisplayContentExtractor = choiceDisplayContentExtractor;

            _backgroundDisplay = backgroundDisplay;
            _backgroundDisplayContentExtractor = backgroundDisplayContentExtractor;
        }

        void IScenePlayer<IChoiceScene>.Play(IChoiceScene choiceScene)
        {
            IChoiceSceneModel choiceSceneModel = choiceScene.ChoiceSceneModel;

            _choiceDisplay.Display(_choiceDisplayContentExtractor.Extract(choiceSceneModel));
            _backgroundDisplay.Display(_backgroundDisplayContentExtractor.Extract(choiceSceneModel));
        }

        void IScenePlayer<IChoiceScene>.End()
        {
            _choiceDisplay.Hide();
            _backgroundDisplay.Hide();
        }
    }
}
