using System.Linq;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ChoiceDisplay;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public interface IChoiceScenModelChoiceChoiceDisplayContentExtractor : ISceneModelExtractor<IChoiceSceneModel, ChoiceDisplayContent> { }

    public class ConcreteChoiceScenModelChoiceChoiceDisplayContentExtractor : IChoiceScenModelChoiceChoiceDisplayContentExtractor
    {
        private readonly ChoiceDisplayContent.Factory _contentFactory;


        public ConcreteChoiceScenModelChoiceChoiceDisplayContentExtractor(ChoiceDisplayContent.Factory contentFactory)
        {
            _contentFactory = contentFactory;
        }

        ChoiceDisplayContent ISceneModelExtractor<IChoiceSceneModel, ChoiceDisplayContent>.Extract(IChoiceSceneModel choiceSceneModel)
        {
            ChoiceDisplayContent.Choice[] choices = choiceSceneModel.Choices.Select(choice => new ChoiceDisplayContent.Choice() { text = choice.Text }).ToArray();
            return _contentFactory.Create(choices);
        }
    }


    public interface IChoiceSceneModelBackgroundDisplayContentExtractor : ISceneModelExtractor<IChoiceSceneModel, BackgroundDisplayContent> { }

    public class ConcreteChoiceSceneModelBackgroundDisplayContentExtractor : IChoiceSceneModelBackgroundDisplayContentExtractor
    {

        private readonly BackgroundDisplayContent.Factory _backgroundDisplayContentFactory;

        public ConcreteChoiceSceneModelBackgroundDisplayContentExtractor(BackgroundDisplayContent.Factory backgroundDisplayContentFactory)
        {
            _backgroundDisplayContentFactory = backgroundDisplayContentFactory;
        }

        BackgroundDisplayContent ISceneModelExtractor<IChoiceSceneModel, BackgroundDisplayContent>.Extract(IChoiceSceneModel choiceSceneModel)
        {
            return _backgroundDisplayContentFactory.Create(choiceSceneModel.Background);
        }
    }
}