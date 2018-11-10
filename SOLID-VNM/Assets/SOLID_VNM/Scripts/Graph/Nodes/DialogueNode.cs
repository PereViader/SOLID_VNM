using UnityEngine;
using XNode;

using SOLID_VNM.Core.Scenes.DialogueScene;

namespace SOLID_VNM.Graph
{
    public interface IDialogueNode : INode
    {
        IDialogueSceneModel DialogueSceneModel { get; }
        INode NextNode { get; }
    }

    public class DialogueNode : BaseNode, IDialogueNode
    {
        [Input] public BaseNode previous;


        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override)]
        public BaseNode next;

        [SerializeField]
        private ConcreteDialogueSceneModel dialogueSceneModel;

        INode IDialogueNode.NextNode { get { return (INode)this.GetOutputConnection("next"); } }

        IDialogueSceneModel IDialogueNode.DialogueSceneModel { get { return dialogueSceneModel; } }

        void INode.Accept(INodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}