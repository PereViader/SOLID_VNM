using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Zenject;

using SOLID_VNM;
using SOLID_VNM.InputManagement;
using SOLID_VNM.Dialogue;
using SOLID_VNM.Displays;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ImageDisplay;

namespace SOLID_VNM.GameBehaviour.Scenes.TextScene
{
    public class TextScenePlayer : IScenePlayer, INextHandler
    {
        readonly private GameLoop _gameLoop;

        readonly private TextDisplayController _textDisplayController;
        readonly private BackgroundDisplayController _backgroundDisplayController;
        readonly private ImageDisplayController _imageDisplayController;
        readonly private IDisplay[] _displays;

        readonly private NextEventRaiser _nextEventRaiser;

        private TextSceneDefinition _textSceneDefinition;

        public TextSceneDefinition TextSceneDefinition { get { return _textSceneDefinition; } set { _textSceneDefinition = value; } }

        public TextScenePlayer(
            TextDisplayController textDisplayController,
            BackgroundDisplayController backgroundDisplayController,
            ImageDisplayController imageDisplayController,
            GameLoop gameLoop,
            NextEventRaiser nextInputEventRaiser)
        {
            _textDisplayController = textDisplayController;
            _backgroundDisplayController = backgroundDisplayController;
            _imageDisplayController = imageDisplayController;

            _displays = new IDisplay[] { _textDisplayController, _backgroundDisplayController, _imageDisplayController };

            _gameLoop = gameLoop;
            _nextEventRaiser = nextInputEventRaiser;
        }

        void IScenePlayer.Play()
        {
            _nextEventRaiser.Push(this);

            foreach (var display in _displays)
            {
                display.Display(_textSceneDefinition.SceneContentDialogue);
            }
        }

        void IScenePlayer.End()
        {
            foreach (var display in _displays)
            {
                display.Hide();
            }

            _nextEventRaiser.Pop();
            TextSceneDefinition = null;
        }

        void INextHandler.OnNext()
        {
            _gameLoop.Play(_textSceneDefinition.NextSceneDefinitionFacade.SceneDefinition);
        }
    }

    public class TextSceneDefinition : ISceneDefinition
    {
        readonly private SceneContentDialogue _sceneContentDialogue;
        readonly private ISceneDefinitionFacade _nextSceneDefinitionFacade;

        public SceneContentDialogue SceneContentDialogue { get { return _sceneContentDialogue; } }

        public ISceneDefinitionFacade NextSceneDefinitionFacade { get { return _nextSceneDefinitionFacade; } }

        public TextSceneDefinition(SceneContentDialogue sceneContentDialogue, ISceneDefinitionFacade nextSceneDefinitionFacade)
        {
            _sceneContentDialogue = sceneContentDialogue;
            _nextSceneDefinitionFacade = nextSceneDefinitionFacade;
        }

        void ISceneDefinition.Accept(ISceneDefinitionVisitor visitor)
        {
            visitor.Accept(this);
        }

        public class Facade : ISceneDefinitionFacade
        {
            readonly private TextSceneDefinition.Factory _textSceneDefinitionFactory;

            readonly private TextNode _textNode;

            public Facade(TextNode textNode, TextSceneDefinition.Factory textSceneDefinitionFactory)
            {
                _textNode = textNode;

                _textSceneDefinitionFactory = textSceneDefinitionFactory;
            }

            public ISceneDefinition SceneDefinition
            {
                get
                {
                    return _textSceneDefinitionFactory.Create(_textNode);
                }
            }

            public class Factory : PlaceholderFactory<TextNode, Facade> { }
        }

        public class Factory : PlaceholderFactory<SceneContentDialogue, ISceneDefinitionFacade, TextSceneDefinition>
        {
            readonly private SceneDefinitionFacadeFactory _sceneDefinitionFacadeFactory;

            public Factory(SceneDefinitionFacadeFactory sceneDefinitionFacadeFactory)
            {
                _sceneDefinitionFacadeFactory = sceneDefinitionFacadeFactory;
            }

            public TextSceneDefinition Create(TextNode textNode)
            {
                return Create(textNode.sceneContentDialogue, _sceneDefinitionFacadeFactory.Create(textNode.Next));
            }
        }
    }
}