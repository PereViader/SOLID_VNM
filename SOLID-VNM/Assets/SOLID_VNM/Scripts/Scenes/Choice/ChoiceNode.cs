﻿using System.Linq;

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
        private readonly XNodeSceneNodeFactorySelector _sceneNodeFactorySelector;
        private readonly XNodeChoiceNodeSceneModelMapper _xNodeChoiceNodeSceneModelFactory;

        private XNodeChoiceNode _choiceNode;

        public ChoiceNodeImpl(XNodeChoiceNode choiceNode, XNodeSceneNodeFactorySelector sceneNodeFactorySelector, XNodeChoiceNodeSceneModelMapper xNodeChoiceNodeSceneModelFactory)
        {
            _sceneNodeFactorySelector = sceneNodeFactorySelector;
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
                return _choiceNode.Choices.Select(choice => _sceneNodeFactorySelector.Create(choice)).ToArray();
            }
        }

        public void Accept(SceneNodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public class Factory : PlaceholderFactory<XNodeChoiceNode, ChoiceNodeImpl> { }
    }
}