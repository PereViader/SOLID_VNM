using UnityEngine;

using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ChoiceDisplay;

namespace SOLID_VNM.Scenes.Choice
{
    public interface ChoiceScenePlayer : ScenePlayer<ChoiceScene> { }

    public class ConcreteChoiceScenePlayer : ChoiceScenePlayer
    {
        private readonly ChoiceDisplay _choiceDisplay;
        private readonly ChoiceScenModelChoiceChoiceDisplayContentExtractor _choiceDisplayContentExtractor;

        private readonly BackgroundDisplay _backgroundDisplay;
        private readonly ChoiceSceneModelBackgroundDisplayContentExtractor _backgroundDisplayContentExtractor;

        public ConcreteChoiceScenePlayer(
            ChoiceDisplay choiceDisplay,
            ChoiceScenModelChoiceChoiceDisplayContentExtractor choiceDisplayContentExtractor,
            BackgroundDisplay backgroundDisplay,
            ChoiceSceneModelBackgroundDisplayContentExtractor backgroundDisplayContentExtractor)
        {
            _choiceDisplay = choiceDisplay;
            _choiceDisplayContentExtractor = choiceDisplayContentExtractor;

            _backgroundDisplay = backgroundDisplay;
            _backgroundDisplayContentExtractor = backgroundDisplayContentExtractor;
        }

        void ScenePlayer<ChoiceScene>.Play(ChoiceScene choiceScene)
        {
            ChoiceSceneModel choiceSceneModel = choiceScene.ChoiceSceneModel;

            _choiceDisplay.Display(_choiceDisplayContentExtractor.From(choiceSceneModel));
            _backgroundDisplay.Display(_backgroundDisplayContentExtractor.From(choiceSceneModel));
        }

        void ScenePlayer<ChoiceScene>.End()
        {
            _choiceDisplay.Stop();
            _backgroundDisplay.Stop();
        }
    }
}
