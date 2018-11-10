using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Graph;
using SOLID_VNM.Core.Scenes;
using SOLID_VNM.Core.Scenes.ChoiceScene;
using SOLID_VNM.Core.Scenes.DialogueScene;

namespace SOLID_VNM.Core.Scenes
{
    public interface ISceneFacade
    {
        IScene Scene { get; }
    }

    public class SceneFacadeFactory : INodeVisitor
    {
        private readonly IDialogueSceneFacadeFactory _dialogueSceneFacadeFactory;
        private readonly IChoiceSceneFacadeFactory _choiceSceneFacadeFactory;

        private ISceneFacade _sceneFacade;

        public SceneFacadeFactory(IDialogueSceneFacadeFactory dialogueSceneFacadeFactory, IChoiceSceneFacadeFactory choiceSceneFacadeFactory)
        {
            _dialogueSceneFacadeFactory = dialogueSceneFacadeFactory;
            _choiceSceneFacadeFactory = choiceSceneFacadeFactory;
        }

        public ISceneFacade Create(INode node)
        {
            node.Accept(this);
            return _sceneFacade;
        }

        public void Visit(IChoiceNode choiceNode)
        {
            _sceneFacade = _choiceSceneFacadeFactory.Create(choiceNode);
        }

        void INodeVisitor.Visit(IDialogueNode dialogueNode)
        {
            _sceneFacade = _dialogueSceneFacadeFactory.Create(dialogueNode);
        }
    }
}
