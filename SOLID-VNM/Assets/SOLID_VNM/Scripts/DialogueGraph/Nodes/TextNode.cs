using XNode;

namespace SOLID_VNM.Dialogue
{
    public class TextNode : DialogueNode
    {
        [Input] public DialogueNode previous;


        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override)]
        public DialogueNode next;

        public SceneContentDialogue sceneContentDialogue;

        public DialogueNode Next { get { return this.GetOutputConnection<DialogueNode>("next"); } }

        public override void Accept(IDialogueNodeVisitor visitor)
        {
            visitor.Accept(this);
        }
    }
}