using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SOLID_VNM.Dialogue;
using SOLID_VNM.Core.Scenes;
using SOLID_VNM.Core.Scenes.TextScene;
using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Core
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
        readonly private TextSceneDefinition.Factory _textSceneDefinitionFactory;
        readonly private ChoiceSceneDefinition.Factory _choiceSceneFactory;

        private ISceneDefinition _sceneDefinition;

        public SceneDefinitionFactory(TextSceneDefinition.Factory textSceneDefinitionFactory, ChoiceSceneDefinition.Factory choiceSceneFactory)
        {
            _textSceneDefinitionFactory = textSceneDefinitionFactory;
            _choiceSceneFactory = choiceSceneFactory;
        }


        public ISceneDefinition Create(DialogueNode dialogueNode)
        {
            dialogueNode.Accept(this);
            return _sceneDefinition;
        }

        public void Accept(ChoiceNode choiceNode)
        {
            _sceneDefinition = _choiceSceneFactory.Create(choiceNode);
        }

        void IDialogueNodeVisitor.Accept(TextNode textNode)
        {
            _sceneDefinition = _textSceneDefinitionFactory.Create(textNode);
        }
    }
}
