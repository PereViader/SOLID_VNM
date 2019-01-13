namespace SOLID_VNM.Graph.XNode
{
    public interface IGraphNode
    {
        void Visit(IGraphNodeVisitor visitor);
    }

    public interface IGraphNodeVisitor
    {
        void Accept(ChoiceNode choiceNode);
        void Accept(DialogueNode dialogueNode);
    }
}