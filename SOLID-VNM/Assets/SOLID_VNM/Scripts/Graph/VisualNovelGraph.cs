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
        private readonly NodeGraphNodeFactory _graphNodeFactory;

        private VNGraph _graph;

        public VisualNovelGraphImpl(VNGraph vngraph, NodeGraphNodeFactory graphNodeFactory)
        {
            _graph = vngraph;
            _graphNodeFactory = graphNodeFactory;
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