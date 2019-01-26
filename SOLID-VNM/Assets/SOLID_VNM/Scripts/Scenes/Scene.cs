using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

using SOLID_VNM.Scenes;
using SOLID_VNM.Scenes.Dialogue;
using SOLID_VNM.Scenes.Choice;

namespace SOLID_VNM.Scenes
{
    public interface Scene
    {
        void Accept(SceneVisitor visitor);
    }

    public interface SceneVisitor
    {
        void Visit(Dialogue.DialogueScene dialogueScene);
        void Visit(Choice.ChoiceScene choiceScene);
    }

    public interface SceneSelectorFactory
    {
        Scene Create(SceneNode sceneNode);
    }

    public class SceneSelectorFactoryImpl : SceneSelectorFactory, SceneNodeVisitor
    {
        private readonly DialogueSceneFactory _dialogueSceneFactory;
        private readonly ChoiceSceneFactory _choiceSceneFactory;

        private Scene _scene;

        public SceneSelectorFactoryImpl(DialogueSceneFactory dialogueSceneFactory, ChoiceSceneFactory choiceSceneFactory)
        {
            _dialogueSceneFactory = dialogueSceneFactory;
            _choiceSceneFactory = choiceSceneFactory;
        }

        Scene SceneSelectorFactory.Create(SceneNode node)
        {
            node.Accept(this);
            return _scene;
        }

        void SceneNodeVisitor.Visit(ChoiceNode choiceNode)
        {
            _scene = _choiceSceneFactory.Create(choiceNode);
        }

        void SceneNodeVisitor.Visit(DialogueNode textNode)
        {
            _scene = _dialogueSceneFactory.Create(textNode);
        }
    }
}
