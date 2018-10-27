using System.Linq;

using ModestTree;
using SOLID_VNM.Core.Scenes.ChoiceScene;
using SOLID_VNM.Core.Scenes.TextScene;

namespace SOLID_VNM.Displays.ChoiceDisplay
{
    public class ChoiceDisplayContentExtractor : ISceneContentVisitor
    {
        readonly private ChoiceDisplayContent.Factory _contentFactory;

        private ChoiceDisplayContent _choiceDisplayContent;

        public ChoiceDisplayContentExtractor(ChoiceDisplayContent.Factory contentFactory)
        {
            _contentFactory = contentFactory;
        }

        public ChoiceDisplayContent Extract(SceneContent sceneContent)
        {
            Assert.IsNotNull(sceneContent);

            sceneContent.Accept(this);
            return _choiceDisplayContent;
        }

        public void Visit(SceneContentDialogue sceneContentDialogue)
        {
            _choiceDisplayContent = null;
        }

        public void Visit(SceneContentChoice sceneContentChoice)
        {
            ChoiceDisplayContent.Choice[] choices = sceneContentChoice.choices.Select(choiceText => new ChoiceDisplayContent.Choice() { text = choiceText }).ToArray();
            _choiceDisplayContent = _contentFactory.Create(choices);
        }
    }
}