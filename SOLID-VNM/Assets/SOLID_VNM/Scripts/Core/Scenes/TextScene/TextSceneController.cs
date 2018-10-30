using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Zenject;

using SOLID_VNM;
using SOLID_VNM.InputManagement;
using SOLID_VNM.Graph;
using SOLID_VNM.Displays;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;
using SOLID_VNM.Displays.ImageDisplay;
using SOLID_VNM.Actors;

namespace SOLID_VNM.Core.Scenes.TextScene
{
    public class TextSceneController : ISceneController, INextHandler
    {
        private readonly GameLoop _gameLoop;
        private readonly ITextScenePlayer _textScenePlayer;
        private readonly NextEventRaiser _nextEventRaiser;

        private TextSceneDefinition _textSceneDefinition;

        public TextSceneDefinition TextSceneDefinition { get { return _textSceneDefinition; } set { _textSceneDefinition = value; } }

        public TextSceneController(
            GameLoop gameLoop,
            ITextScenePlayer textScenePlayer,
            NextEventRaiser nextInputEventRaiser)
        {
            _gameLoop = gameLoop;
            _textScenePlayer = textScenePlayer;
            _nextEventRaiser = nextInputEventRaiser;
        }

        void ISceneController.Play()
        {
            _nextEventRaiser.NextHandler = this;
            _textScenePlayer.Play(_textSceneDefinition);
        }

        void ISceneController.End()
        {
            _nextEventRaiser.NextHandler = null;
            _textSceneDefinition = null;
            _textScenePlayer.End();
        }

        void INextHandler.OnNext()
        {
            _gameLoop.Play(_textSceneDefinition.NextSceneDefinitionFacade.SceneDefinition);
        }
    }
}