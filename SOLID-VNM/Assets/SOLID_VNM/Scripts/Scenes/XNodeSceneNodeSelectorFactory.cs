using Zenject;

using SOLID_VNM.Scenes.Choice;
using SOLID_VNM.Scenes.Dialogue;

namespace SOLID_VNM.Scenes
{
    public interface XNodeSceneNodeSelectorFactory
    {
        SceneNode Create(XNodeSceneNode node);
    }

    public class XNodeSceneNodeSelectorFactoryImpl : XNodeSceneNodeSelectorFactory, XNodeSceneNodeVisitor
    {
        private readonly DialogueNodeImpl.Factory _dialogueNodeFactory;
        private readonly ChoiceNodeImpl.Factory _choiceNodeFactory;

        private SceneNode _node;

        public XNodeSceneNodeSelectorFactoryImpl(DialogueNodeImpl.Factory dialogueNodeFactory, ChoiceNodeImpl.Factory choiceNodeFactory)
        {
            _dialogueNodeFactory = dialogueNodeFactory;
            _choiceNodeFactory = choiceNodeFactory;
        }

        SceneNode XNodeSceneNodeSelectorFactory.Create(XNodeSceneNode node)
        {
            BuildNode(node);
            return _node;
        }

        private void BuildNode(XNodeSceneNode graphNode)
        {
            _node = null;
            graphNode.Visit(this);
        }

        void XNodeSceneNodeVisitor.Accept(XNodeChoiceNode choiceNode)
        {
            _node = _choiceNodeFactory.Create(choiceNode);
        }

        void XNodeSceneNodeVisitor.Accept(XNodeDialogueNode dialogueNode)
        {
            _node = _dialogueNodeFactory.Create(dialogueNode);
        }
    }
}