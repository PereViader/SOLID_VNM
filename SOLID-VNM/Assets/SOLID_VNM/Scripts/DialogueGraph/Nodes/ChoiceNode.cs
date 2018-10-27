using XNode;

using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Dialogue
{
    public class ChoiceNode : DialogueNode
    {
        [Input] public DialogueNode previous;


        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Multiple)]
        public DialogueNode choices;

        public SceneContentChoice sceneContentChoice;

        public DialogueNode[] Choices { get { return this.GetOutputConnections<DialogueNode>("choices"); } }

        public override void Accept(IDialogueNodeVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}