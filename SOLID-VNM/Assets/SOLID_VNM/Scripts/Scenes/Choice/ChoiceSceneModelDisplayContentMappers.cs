using System.Linq;

using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ChoiceDisplay;

using SOLID_VNM.Displays.BackgroundDisplay.NoTransitionBehaviour;

namespace SOLID_VNM.Scenes.Choice
{
    public interface ChoiceScenModelChoiceChoiceDisplayContentExtractor : SceneModelDisplayContentMapper<ChoiceSceneModel, ChoiceDisplayContent> { }

    public class ChoiceScenModelChoiceChoiceDisplayContentExtractorImpl : ChoiceScenModelChoiceChoiceDisplayContentExtractor
    {
        private readonly ChoiceDisplayContent.Factory _contentFactory;


        public ChoiceScenModelChoiceChoiceDisplayContentExtractorImpl(ChoiceDisplayContent.Factory contentFactory)
        {
            _contentFactory = contentFactory;
        }

        ChoiceDisplayContent SceneModelDisplayContentMapper<ChoiceSceneModel, ChoiceDisplayContent>.From(ChoiceSceneModel choiceSceneModel)
        {
            ChoiceDisplayContent.Choice[] choices = choiceSceneModel.Choices.Select(choice => new ChoiceDisplayContent.Choice() { text = choice.Text }).ToArray();
            return _contentFactory.Create(choices);
        }
    }


    public interface ChoiceSceneModelBackgroundDisplayContentExtractor : SceneModelDisplayContentMapper<ChoiceSceneModel, NoTransitionBackgroundDisplayModel> { }

    public class ChoiceSceneModelBackgroundDisplayContentExtractorImpl : ChoiceSceneModelBackgroundDisplayContentExtractor
    {

        private readonly NoTransitionBackgroundDisplayModel.Factory _backgroundDisplayContentFactory;

        public ChoiceSceneModelBackgroundDisplayContentExtractorImpl(NoTransitionBackgroundDisplayModel.Factory backgroundDisplayContentFactory)
        {
            _backgroundDisplayContentFactory = backgroundDisplayContentFactory;
        }

        NoTransitionBackgroundDisplayModel SceneModelDisplayContentMapper<ChoiceSceneModel, NoTransitionBackgroundDisplayModel>.From(ChoiceSceneModel choiceSceneModel)
        {
            return _backgroundDisplayContentFactory.Create(choiceSceneModel.Background);
        }
    }
}