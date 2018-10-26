using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Dialogue;
using SOLID_VNM.GameBehaviour.Scenes;
using SOLID_VNM.GameBehaviour.Scenes.TextScene;

namespace SOLID_VNM.GameBehaviour
{
    public interface ISceneDefinitionFacade
    {
        ISceneDefinition SceneDefinition { get; }
    }

    public class SceneDefinitionFacadeFactory : IDialogueNodeVisitor
    {
        private TextSceneDefinition.Facade.Factory _textSceneDefinitionFacadeFactory;

        private ISceneDefinitionFacade _sceneDefinitionFacade;

        public SceneDefinitionFacadeFactory(TextSceneDefinition.Facade.Factory textSceneDefinitionFacadeFactory)
        {
            _textSceneDefinitionFacadeFactory = textSceneDefinitionFacadeFactory;
        }

        public ISceneDefinitionFacade Create(DialogueNode dialogueNode)
        {
            dialogueNode.Accept(this);
            return _sceneDefinitionFacade;
        }

        void IDialogueNodeVisitor.Accept(TextNode textNode)
        {
            _sceneDefinitionFacade = _textSceneDefinitionFacadeFactory.Create(textNode);
        }
    }
}
