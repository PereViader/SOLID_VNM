using UnityEngine;
using Zenject;

namespace SOLID_VNM.Scenes.Dialogue
{
    public interface DialogueNode : SceneNode
    {
        DialogueSceneModel DialogueSceneModel { get; }
        SceneNode NextNode { get; }
    }

    public class DialogueNodeImpl : DialogueNode
    {
        private readonly XNodeSceneNodeFactorySelector _xNodeGraphNodeSceneNodeMapper;
        private readonly XNodeDialogueNodeSceneModelMapper _dialogueNodeSceneModelMapper;



        private XNodeDialogueNode _dialogueNode;


        public DialogueNodeImpl(XNodeDialogueNode dialogueNode, XNodeSceneNodeFactorySelector xNodeGraphNodeSceneNodeMapper, XNodeDialogueNodeSceneModelMapper dialogueNodeSceneModelMapper)
        {
            _dialogueNode = dialogueNode;
            _xNodeGraphNodeSceneNodeMapper = xNodeGraphNodeSceneNodeMapper;
            _dialogueNodeSceneModelMapper = dialogueNodeSceneModelMapper;
        }

        public DialogueSceneModel DialogueSceneModel
        {
            get
            {
                return _dialogueNodeSceneModelMapper.From(_dialogueNode.Model);
            }
        }

        public SceneNode NextNode
        {
            get
            {
                return _xNodeGraphNodeSceneNodeMapper.Create(_dialogueNode.NextNode);
            }
        }

        public void Accept(SceneNodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public class Factory : PlaceholderFactory<XNodeDialogueNode, DialogueNodeImpl> { }
    }
}