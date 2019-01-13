using UnityEngine;
using XNode;

using SOLID_VNM.Core.Scenes.DialogueScene;

namespace SOLID_VNM.Graph.XNode
{
    public class DialogueNode : Node, IGraphNode
    {
        [Input]
        public Node previous;

        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override)]
        public Node next;


        [SerializeField]
        private ConcreteDialogueSceneModel dialogueSceneModel;


        public IGraphNode NextNode { get { return (IGraphNode)this.GetOutputConnection("next"); } }

        public IDialogueSceneModel DialogueSceneModel { get { return dialogueSceneModel; } }

        public void Visit(IGraphNodeVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}