using System.Linq;
using UnityEngine;
using Zenject;

using SOLID_VNM.Core.Scenes.ChoiceScene;
using SOLID_VNM.Graph.XNode;

namespace SOLID_VNM.Graph
{
    public interface IChoiceNode : INode
    {
        IChoiceSceneModel ChoiceSceneModel { get; }
        INode[] Choices { get; }
    }

    public class ChoiceNodeImpl : IChoiceNode
    {
        private readonly NodeGraphNodeFactory _graphNodeFactory;

        private ChoiceNode _choiceNode;


        public ChoiceNodeImpl(ChoiceNode choiceNode, NodeGraphNodeFactory graphNodeFactory)
        {
            _graphNodeFactory = graphNodeFactory;
            _choiceNode = choiceNode;
        }

        public IChoiceSceneModel ChoiceSceneModel
        {
            get
            {
                return _choiceNode.ChoiceSceneModel;
            }
        }

        public INode[] Choices
        {
            get
            {
                return _choiceNode.Choices.Select(choice => _graphNodeFactory.Create(choice)).ToArray();
            }
        }

        public void Accept(INodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public class Factory : PlaceholderFactory<ChoiceNode, ChoiceNodeImpl> { }
    }
}