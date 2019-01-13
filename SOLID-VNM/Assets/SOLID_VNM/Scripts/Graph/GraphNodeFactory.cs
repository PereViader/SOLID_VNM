using Zenject;
using System.Linq;
using SOLID_VNM.Graph.XNode;

namespace SOLID_VNM.Graph
{

    public interface INodeGraphNodeFactory : IFactory<IGraphNode, INode>, IFactory<IGraphNode[], INode[]>
    {
    }

    public class NodeGraphNodeFactoryImpl : INodeGraphNodeFactory, IGraphNodeVisitor
    {
        private readonly DialogueNodeImpl.Factory _dialogueNodeFactory;
        private readonly ChoiceNodeImpl.Factory _choiceNodeFactory;

        private INode _node;

        public NodeGraphNodeFactoryImpl(DialogueNodeImpl.Factory dialogueNodeFactory, ChoiceNodeImpl.Factory choiceNodeFactory)
        {
            _dialogueNodeFactory = dialogueNodeFactory;
            _choiceNodeFactory = choiceNodeFactory;
        }

        INode IFactory<IGraphNode, INode>.Create(IGraphNode graphNode)
        {
            return Create(graphNode);
        }

        INode[] IFactory<IGraphNode[], INode[]>.Create(IGraphNode[] graphNodes)
        {
            return graphNodes.Select(graphNode => Create(graphNode)).ToArray();
        }

        private INode Create(IGraphNode graphNode)
        {
            BuildNode(graphNode);
            return _node;
        }

        private void BuildNode(IGraphNode graphNode)
        {
            _node = null;
            graphNode.Visit(this);
        }

        public void Accept(ChoiceNode choiceNode)
        {
            _node = _choiceNodeFactory.Create(choiceNode);
        }

        public void Accept(DialogueNode dialogueNode)
        {
            _node = _dialogueNodeFactory.Create(dialogueNode);
        }
    }
}