using XNode;

using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Graph
{
    public class ChoiceNode : VNNode
    {
        [Input] public VNNode previous;


        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Multiple)]
        public VNNode choices;

        public SceneContentChoice sceneContentChoice;

        public VNNode[] Choices { get { return this.GetOutputConnections<VNNode>("choices"); } }

        public override void Accept(IDialogueNodeVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}