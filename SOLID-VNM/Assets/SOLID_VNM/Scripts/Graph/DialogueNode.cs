using UnityEngine;
using Zenject;
using XNode;

using SOLID_VNM.Core.Scenes.DialogueScene;
using SOLID_VNM.Graph.XNode;

namespace SOLID_VNM.Graph
{
    public interface IDialogueNode : INode
    {
        IDialogueSceneModel DialogueSceneModel { get; }
        INode NextNode { get; }
    }

    public class DialogueNodeImpl : IDialogueNode
    {
        private readonly INodeGraphNodeFactory _graphNodeFactory;

        private DialogueNode _dialogueNode;


        public DialogueNodeImpl(DialogueNode dialogueNode, INodeGraphNodeFactory graphNodeFactory)
        {
            _graphNodeFactory = graphNodeFactory;
            _dialogueNode = dialogueNode;
        }

        public IDialogueSceneModel DialogueSceneModel
        {
            get
            {
                return _dialogueNode.DialogueSceneModel;
            }
        }

        public INode NextNode
        {
            get
            {
                return _graphNodeFactory.Create(_dialogueNode.NextNode);
            }
        }

        public void Accept(INodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public class Factory : PlaceholderFactory<DialogueNode, DialogueNodeImpl> { }
    }
}