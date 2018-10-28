using System.Linq;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ChoiceDisplay;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public interface ISceneContentChoiceChoiceDisplayContentExtractor : ISceneContentExtractor<SceneContentChoice, ChoiceDisplayContent>
    {
    }

    public class SceneContentChoiceChoiceDisplayContentExtractor : ISceneContentChoiceChoiceDisplayContentExtractor
    {
        readonly private ChoiceDisplayContent.Factory _contentFactory;


        public SceneContentChoiceChoiceDisplayContentExtractor(ChoiceDisplayContent.Factory contentFactory)
        {
            _contentFactory = contentFactory;
        }

        ChoiceDisplayContent ISceneContentExtractor<SceneContentChoice, ChoiceDisplayContent>.Extract(SceneContentChoice sceneContentChoice)
        {
            ChoiceDisplayContent.Choice[] choices = sceneContentChoice.choices.Select(choiceText => new ChoiceDisplayContent.Choice() { text = choiceText }).ToArray();
            return _contentFactory.Create(choices);
        }
    }


    public interface ISceneContentChoiceBackgroundDisplayContentExtractor : ISceneContentExtractor<SceneContentChoice, BackgroundDisplayContent> { }

    public class SceneContentChoiceBackgroundDisplayContentExtractor : ISceneContentChoiceBackgroundDisplayContentExtractor
    {

        readonly private BackgroundDisplayContent.Factory _backgroundDisplayContentFactory;

        public SceneContentChoiceBackgroundDisplayContentExtractor(BackgroundDisplayContent.Factory backgroundDisplayContentFactory)
        {
            _backgroundDisplayContentFactory = backgroundDisplayContentFactory;
        }

        BackgroundDisplayContent ISceneContentExtractor<SceneContentChoice, BackgroundDisplayContent>.Extract(SceneContentChoice content)
        {
            return _backgroundDisplayContentFactory.Create(content.background);
        }
    }
}