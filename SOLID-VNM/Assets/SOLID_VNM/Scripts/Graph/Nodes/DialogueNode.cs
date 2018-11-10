using XNode;

using SOLID_VNM.Core.Scenes.DialogueScene;

namespace SOLID_VNM.Graph
{
    public class DialogueNode : VNNode
    {
        [Input] public VNNode previous;


        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override)]
        public VNNode next;

        public ConcreteDialogueSceneModel dialogueSceneModel;

        public VNNode Next { get { return this.GetOutputConnection<VNNode>("next"); } }

        public override void Accept(IDialogueNodeVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}