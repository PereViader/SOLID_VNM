using System.Linq;

using UnityEngine;
using Zenject;

namespace SOLID_VNM.Scenes.Choice
{
    public interface ChoiceNode : SceneNode
    {
        ChoiceSceneModel ChoiceSceneModel { get; }
        SceneNode[] Choices { get; }
    }

    public class ChoiceNodeImpl : ChoiceNode
    {
        private readonly XNodeSceneNodeSelectorFactory _sceneNodeSelectorFactory;
        private readonly XNodeChoiceNodeSceneModelMapper _xNodeChoiceNodeSceneModelFactory;

        private XNodeChoiceNode _choiceNode;

        public ChoiceNodeImpl(XNodeChoiceNode choiceNode, XNodeSceneNodeSelectorFactory sceneNodeSelectorFactory, XNodeChoiceNodeSceneModelMapper xNodeChoiceNodeSceneModelFactory)
        {
            _sceneNodeSelectorFactory = sceneNodeSelectorFactory;
            _choiceNode = choiceNode;
            _xNodeChoiceNodeSceneModelFactory = xNodeChoiceNodeSceneModelFactory;
        }

        public ChoiceSceneModel ChoiceSceneModel
        {
            get
            {
                return _xNodeChoiceNodeSceneModelFactory.From(_choiceNode.Model);
            }
        }

        public SceneNode[] Choices
        {
            get
            {
                return _choiceNode.Choices.Select(choice => _sceneNodeSelectorFactory.Create(choice)).ToArray();
            }
        }

        public void Accept(SceneNodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public class Factory : PlaceholderFactory<XNodeChoiceNode, ChoiceNodeImpl> { }
    }
}