using ModestTree;

namespace SOLID_VNM.Displays.ChoiceDisplay
{
    public class ChoiceDisplayContentExtractor : ISceneContentVisitor
    {
        //readonly private ChoiceDisplayContent.Factory _contentFactory;

        private ChoiceDisplayContent _choiceDisplayContent;

        public ChoiceDisplayContentExtractor(ChoiceDisplayContent.Factory contentFactory)
        {
            //_contentFactory = contentFactory;
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
    }
}