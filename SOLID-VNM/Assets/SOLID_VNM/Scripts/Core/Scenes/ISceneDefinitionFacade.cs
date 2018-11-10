using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Graph;
using SOLID_VNM.Core.Scenes;
using SOLID_VNM.Core.Scenes.ChoiceScene;
using SOLID_VNM.Core.Scenes.DialogueScene;

namespace SOLID_VNM.Core.Scenes
{
    public interface ISceneDefinitionFacade
    {
        ISceneDefinition SceneDefinition { get; }
    }

    public class SceneDefinitionFacadeFactory : IDialogueNodeVisitor
    {
        private TextSceneDefinition.Facade.Factory _textSceneDefinitionFacadeFactory;
        private ChoiceSceneDefinition.Facade.Factory _choiceSceneDefinitionFacadeFactory;

        private ISceneDefinitionFacade _sceneDefinitionFacade;

        public SceneDefinitionFacadeFactory(TextSceneDefinition.Facade.Factory textSceneDefinitionFacadeFactory, ChoiceSceneDefinition.Facade.Factory choiceSceneDefinitionFacadeFactory)
        {
            _textSceneDefinitionFacadeFactory = textSceneDefinitionFacadeFactory;
            _choiceSceneDefinitionFacadeFactory = choiceSceneDefinitionFacadeFactory;
        }

        public ISceneDefinitionFacade Create(VNNode dialogueNode)
        {
            dialogueNode.Accept(this);
            return _sceneDefinitionFacade;
        }

        public void Accept(ChoiceNode choiceNode)
        {
            _sceneDefinitionFacade = _choiceSceneDefinitionFacadeFactory.Create(choiceNode);
        }

        void IDialogueNodeVisitor.Accept(DialogueNode textNode)
        {
            _sceneDefinitionFacade = _textSceneDefinitionFacadeFactory.Create(textNode);
        }
    }
}
