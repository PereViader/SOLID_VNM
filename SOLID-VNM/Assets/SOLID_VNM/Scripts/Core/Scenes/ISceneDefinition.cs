using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SOLID_VNM.Graph;
using SOLID_VNM.Core.Scenes;
using SOLID_VNM.Core.Scenes.DialogueScene;
using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Core.Scenes
{
    public interface ISceneDefinition
    {
        void Accept(ISceneDefinitionVisitor visitor);
    }

    public interface ISceneDefinitionVisitor
    {
        void Accept(TextSceneDefinition textSceneDefinition);
        void Accept(ChoiceSceneDefinition choiceSceneDefinition);
    }

    public class SceneDefinitionFactory : IDialogueNodeVisitor
    {
        private readonly TextSceneDefinition.Factory _textSceneDefinitionFactory;
        private readonly ChoiceSceneDefinition.Factory _choiceSceneFactory;

        private ISceneDefinition _sceneDefinition;

        public SceneDefinitionFactory(TextSceneDefinition.Factory textSceneDefinitionFactory, ChoiceSceneDefinition.Factory choiceSceneFactory)
        {
            _textSceneDefinitionFactory = textSceneDefinitionFactory;
            _choiceSceneFactory = choiceSceneFactory;
        }


        public ISceneDefinition Create(VNNode dialogueNode)
        {
            dialogueNode.Accept(this);
            return _sceneDefinition;
        }

        public void Accept(ChoiceNode choiceNode)
        {
            _sceneDefinition = _choiceSceneFactory.Create(choiceNode);
        }

        void IDialogueNodeVisitor.Accept(DialogueNode textNode)
        {
            _sceneDefinition = _textSceneDefinitionFactory.Create(textNode);
        }
    }
}
