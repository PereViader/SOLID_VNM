using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SOLID_VNM.Dialogue;
using SOLID_VNM.GameBehaviour.Scenes;
using SOLID_VNM.GameBehaviour.Scenes.TextScene;

namespace SOLID_VNM.GameBehaviour
{
    public interface ISceneDefinition
    {
        void Accept(ISceneDefinitionVisitor visitor);
    }

    public interface ISceneDefinitionVisitor
    {
        void Accept(TextSceneDefinition textSceneDefinition);
    }

    public class SceneDefinitionFactory : IDialogueNodeVisitor
    {
        readonly private TextSceneDefinition.Factory _textSceneDefinitionFactory;

        private ISceneDefinition _sceneDefinition;

        public SceneDefinitionFactory(TextSceneDefinition.Factory textSceneDefinitionFactory)
        {
            _textSceneDefinitionFactory = textSceneDefinitionFactory;
        }

        public ISceneDefinition Create(DialogueNode dialogueNode)
        {
            dialogueNode.Accept(this);
            return _sceneDefinition;
        }

        void IDialogueNodeVisitor.Accept(TextNode textNode)
        {
            _sceneDefinition = _textSceneDefinitionFactory.Create(textNode);
        }
    }
}
