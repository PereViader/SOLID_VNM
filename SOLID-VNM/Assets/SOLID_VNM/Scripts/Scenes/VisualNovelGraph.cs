using Zenject;

namespace SOLID_VNM.Scenes
{
    public interface VisualNovelGraph
    {
        SceneNode RootNode { get; }
    }

    public class VisualNovelGraphImpl : VisualNovelGraph
    {
        private readonly XNodeSceneNodeFactorySelector _xNodeGraphNodeSceneNodeMapper;

        private XNodeVisualNovelGraph _graph;

        public VisualNovelGraphImpl(XNodeVisualNovelGraph vngraph, XNodeSceneNodeFactorySelector xNodeGraphNodeSceneNodeMapper)
        {
            _graph = vngraph;
            _xNodeGraphNodeSceneNodeMapper = xNodeGraphNodeSceneNodeMapper;
        }

        public SceneNode RootNode
        {
            get
            {
                return _xNodeGraphNodeSceneNodeMapper.Create(_graph.RootNode);
            }
        }

        public class Factory : PlaceholderFactory<XNodeVisualNovelGraph, VisualNovelGraphImpl> { }
    }
}