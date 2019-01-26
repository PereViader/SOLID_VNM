using System.Linq;

using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ChoiceDisplay;

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


    public interface ChoiceSceneModelBackgroundDisplayContentExtractor : SceneModelDisplayContentMapper<ChoiceSceneModel, BackgroundDisplayContent> { }

    public class ChoiceSceneModelBackgroundDisplayContentExtractorImpl : ChoiceSceneModelBackgroundDisplayContentExtractor
    {

        private readonly BackgroundDisplayContent.Factory _backgroundDisplayContentFactory;

        public ChoiceSceneModelBackgroundDisplayContentExtractorImpl(BackgroundDisplayContent.Factory backgroundDisplayContentFactory)
        {
            _backgroundDisplayContentFactory = backgroundDisplayContentFactory;
        }

        BackgroundDisplayContent SceneModelDisplayContentMapper<ChoiceSceneModel, BackgroundDisplayContent>.From(ChoiceSceneModel choiceSceneModel)
        {
            return _backgroundDisplayContentFactory.Create(choiceSceneModel.Background);
        }
    }
}