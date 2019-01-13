using SOLID_VNM.Graph.XNode;
using Zenject;

namespace SOLID_VNM.Graph
{
    public interface IVisualNovelGraph
    {
        INode RootNode { get; }
    }

    public class VisualNovelGraphImpl : IVisualNovelGraph
    {
        private readonly INodeGraphNodeFactory _graphNodeFactory;

        private VNGraph _graph;

        public VisualNovelGraphImpl(VNGraph vngraph, INodeGraphNodeFactory _graphNodeFactory)
        {
            _graph = vngraph;
        }

        public INode RootNode
        {
            get
            {
                return _graphNodeFactory.Create(_graph.RootNode);
            }
        }

        public class Factory : PlaceholderFactory<VNGraph, VisualNovelGraphImpl> { }
    }
}