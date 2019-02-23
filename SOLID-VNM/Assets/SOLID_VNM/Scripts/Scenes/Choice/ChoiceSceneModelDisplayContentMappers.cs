using System.Linq;

using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ChoiceDisplay;

using SOLID_VNM.Displays.BackgroundDisplay.FadeInTransitionBehaviour;

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


    public interface ChoiceSceneModelBackgroundDisplayContentExtractor : SceneModelDisplayContentMapper<ChoiceSceneModel, FadeInTransitionBackgroundDisplayModel> { }

    public class ChoiceSceneModelBackgroundDisplayContentExtractorImpl : ChoiceSceneModelBackgroundDisplayContentExtractor
    {

        private readonly FadeInTransitionBackgroundDisplayModel.Factory _backgroundDisplayContentFactory;

        public ChoiceSceneModelBackgroundDisplayContentExtractorImpl(FadeInTransitionBackgroundDisplayModel.Factory backgroundDisplayContentFactory)
        {
            _backgroundDisplayContentFactory = backgroundDisplayContentFactory;
        }

        FadeInTransitionBackgroundDisplayModel SceneModelDisplayContentMapper<ChoiceSceneModel, FadeInTransitionBackgroundDisplayModel>.From(ChoiceSceneModel choiceSceneModel)
        {
            return _backgroundDisplayContentFactory.Create(choiceSceneModel.Background, 5f);
        }
    }
}