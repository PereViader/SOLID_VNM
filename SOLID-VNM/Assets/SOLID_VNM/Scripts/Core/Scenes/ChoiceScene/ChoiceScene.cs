using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Core;
using SOLID_VNM.Dialogue;
using SOLID_VNM.Displays;
using SOLID_VNM.Displays.ChoiceDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ImageDisplay;
using Zenject;
using System;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    public class ChoiceScenePlayer : IScenePlayer, IChoiceHandler
    {
        readonly private ChoiceDisplayController _choiceDisplayController;
        readonly private BackgroundDisplayController _backgroundDisplayController;
        readonly private IDisplay[] _displays;

        readonly private GameLoop _gameLoop;
        readonly private ChoiceEventRaiser _choiceEventRaiser;


        private ChoiceSceneDefinition _choiceSceneDefinition;
        public ChoiceSceneDefinition ChoiceSceneDefinition { get { return _choiceSceneDefinition; } set { _choiceSceneDefinition = value; } }


        public ChoiceScenePlayer(ChoiceDisplayController choiceDisplayController, BackgroundDisplayController backgroundDisplayController, ChoiceEventRaiser choiceEventRaiser, GameLoop gameLoop)
        {
            _gameLoop = gameLoop;
            _choiceEventRaiser = choiceEventRaiser;

            _choiceDisplayController = choiceDisplayController;
            _backgroundDisplayController = backgroundDisplayController;
            _displays = new IDisplay[] { _choiceDisplayController, _backgroundDisplayController };
        }

        void IScenePlayer.Play()
        {
            _choiceEventRaiser.Push(this);
            _choiceEventRaiser.enabled = true;

            foreach (var display in _displays)
            {
                display.Display(_choiceSceneDefinition.SceneContentChoice);
            }
        }

        void IScenePlayer.End()
        {
            _choiceEventRaiser.enabled = false;
            _choiceEventRaiser.Pop();

            foreach (var display in _displays)
            {
                display.Hide();
            }
        }

        void IChoiceHandler.OnChoice(int choice)
        {
            _gameLoop.Play(_choiceSceneDefinition.SceneDefinitionFacades[choice].SceneDefinition);
        }
    }

    public class ChoiceSceneDefinition : ISceneDefinition
    {
        readonly private SceneContentChoice _sceneContentChoice;
        readonly private ISceneDefinitionFacade[] _sceneDefinitionFacades;

        public SceneContentChoice SceneContentChoice { get { return _sceneContentChoice; } }
        public ISceneDefinitionFacade[] SceneDefinitionFacades { get { return _sceneDefinitionFacades; } }

        public ChoiceSceneDefinition(SceneContentChoice sceneContentChoice, ISceneDefinitionFacade[] sceneDefinitionFacades)
        {
            _sceneContentChoice = sceneContentChoice;
            _sceneDefinitionFacades = sceneDefinitionFacades;
        }

        void ISceneDefinition.Accept(ISceneDefinitionVisitor visitor)
        {
            visitor.Accept(this);
        }

        public class Facade : ISceneDefinitionFacade
        {
            readonly private ChoiceSceneDefinition.Factory _choiceSceneDefinitionFactory;
            readonly private ChoiceNode _choiceNode;


            public Facade(ChoiceSceneDefinition.Factory choiceSceneDefinitionFactory, ChoiceNode choiceNode)
            {
                _choiceSceneDefinitionFactory = choiceSceneDefinitionFactory;
                _choiceNode = choiceNode;
            }

            ISceneDefinition ISceneDefinitionFacade.SceneDefinition
            {
                get
                {
                    return _choiceSceneDefinitionFactory.Create(_choiceNode);
                }
            }

            public class Factory : PlaceholderFactory<ChoiceNode, Facade> { }
        }

        public class Factory : PlaceholderFactory<SceneContentChoice, ISceneDefinitionFacade[], ChoiceSceneDefinition>, IFactory<ChoiceNode, ChoiceSceneDefinition>
        {
            readonly private SceneDefinitionFacadeFactory _sceneDefinitionFacadeFactory;

            public Factory(SceneDefinitionFacadeFactory sceneDefinitionFacadeFactory)
            {
                _sceneDefinitionFacadeFactory = sceneDefinitionFacadeFactory;
            }

            public ChoiceSceneDefinition Create(ChoiceNode choiceNode)
            {
                ISceneDefinitionFacade[] sceneDefinitionFacades = choiceNode.Choices.Select(node => _sceneDefinitionFacadeFactory.Create(node)).ToArray();
                return Create(choiceNode.sceneContentChoice, sceneDefinitionFacades);
            }
        }
    }

    [Serializable]
    public class SceneContentChoice : SceneContent
    {
        public Sprite background;
        public string[] choices;


        public override void Accept(ISceneContentVisitor sceneContentVisitor)
        {
            sceneContentVisitor.Visit(this);
        }
    }
}
