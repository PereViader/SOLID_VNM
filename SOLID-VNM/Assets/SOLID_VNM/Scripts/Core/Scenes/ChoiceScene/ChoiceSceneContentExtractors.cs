using System.Linq;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ChoiceDisplay;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public interface ISceneContentChoiceChoiceDisplayContentExtractor : ISceneModelExtractor<IChoiceSceneModel, ChoiceDisplayContent>
    {
    }

    public class SceneContentChoiceChoiceDisplayContentExtractor : ISceneContentChoiceChoiceDisplayContentExtractor
    {
        private readonly ChoiceDisplayContent.Factory _contentFactory;


        public SceneContentChoiceChoiceDisplayContentExtractor(ChoiceDisplayContent.Factory contentFactory)
        {
            _contentFactory = contentFactory;
        }

        ChoiceDisplayContent ISceneModelExtractor<IChoiceSceneModel, ChoiceDisplayContent>.Extract(IChoiceSceneModel sceneContentChoice)
        {
            ChoiceDisplayContent.Choice[] choices = sceneContentChoice.Choices.Select(choice => new ChoiceDisplayContent.Choice() { text = choice.Text }).ToArray();
            return _contentFactory.Create(choices);
        }
    }


    public interface ISceneContentChoiceBackgroundDisplayContentExtractor : ISceneModelExtractor<IChoiceSceneModel, BackgroundDisplayContent> { }

    public class SceneContentChoiceBackgroundDisplayContentExtractor : ISceneContentChoiceBackgroundDisplayContentExtractor
    {

        private readonly BackgroundDisplayContent.Factory _backgroundDisplayContentFactory;

        public SceneContentChoiceBackgroundDisplayContentExtractor(BackgroundDisplayContent.Factory backgroundDisplayContentFactory)
        {
            _backgroundDisplayContentFactory = backgroundDisplayContentFactory;
        }

        BackgroundDisplayContent ISceneModelExtractor<IChoiceSceneModel, BackgroundDisplayContent>.Extract(IChoiceSceneModel content)
        {
            return _backgroundDisplayContentFactory.Create(content.Background);
        }
    }
}