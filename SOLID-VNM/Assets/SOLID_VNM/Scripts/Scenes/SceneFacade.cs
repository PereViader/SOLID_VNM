using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Zenject;

using SOLID_VNM.Scenes;
using SOLID_VNM.Scenes.Choice;
using SOLID_VNM.Scenes.Dialogue;

namespace SOLID_VNM.Scenes
{
    public interface SceneFacade
    {
        Scene Scene { get; }
    }

    public interface SceneFacadeSelectorFactory
    {
        SceneFacade Create(SceneNode sceneNode);
    }

    public class SceneFacadeSelectorFactoryImpl : SceneFacadeSelectorFactory, SceneNodeVisitor
    {
        private readonly DialogueSceneFacadeFactory _dialogueSceneFacadeFactory;
        private readonly ChoiceSceneFacadeFactory _choiceSceneFacadeFactory;

        private SceneFacade _sceneFacade;

        public SceneFacadeSelectorFactoryImpl(DialogueSceneFacadeFactory dialogueSceneFacadeFactory, ChoiceSceneFacadeFactory choiceSceneFacadeFactory)
        {
            _dialogueSceneFacadeFactory = dialogueSceneFacadeFactory;
            _choiceSceneFacadeFactory = choiceSceneFacadeFactory;
        }

        SceneFacade SceneFacadeSelectorFactory.Create(SceneNode node)
        {
            node.Accept(this);
            return _sceneFacade;
        }

        public void Visit(ChoiceNode choiceNode)
        {
            _sceneFacade = _choiceSceneFacadeFactory.Create(choiceNode);
        }

        void SceneNodeVisitor.Visit(DialogueNode dialogueNode)
        {
            _sceneFacade = _dialogueSceneFacadeFactory.Create(dialogueNode);
        }
    }
}
