using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SOLID_VNM.Graph;
using SOLID_VNM.Core.Scenes;
using SOLID_VNM.Core.Scenes.DialogueScene;
using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Core.Scenes
{
    public interface IScene
    {
        void Accept(ISceneVisitor visitor);
    }

    public interface ISceneVisitor
    {
        void Visit(IDialogueScene dialogueScene);
        void Visit(IChoiceScene choiceScene);
    }

    public class SceneFactory : INodeVisitor
    {
        private readonly IDialogueSceneFactory _dialogueSceneFactory;
        private readonly IChoiceSceneFactory _choiceSceneFactory;

        private IScene _scene;

        public SceneFactory(IDialogueSceneFactory dialogueSceneFactory, IChoiceSceneFactory choiceSceneFactory)
        {
            _dialogueSceneFactory = dialogueSceneFactory;
            _choiceSceneFactory = choiceSceneFactory;
        }


        public IScene Create(INode node)
        {
            node.Accept(this);
            return _scene;
        }

        void INodeVisitor.Visit(IChoiceNode choiceNode)
        {
            _scene = _choiceSceneFactory.Create(choiceNode);
        }

        void INodeVisitor.Visit(IDialogueNode textNode)
        {
            _scene = _dialogueSceneFactory.Create(textNode);
        }
    }
}
