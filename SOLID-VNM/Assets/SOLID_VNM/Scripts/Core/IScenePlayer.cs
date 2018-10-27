using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM;
using SOLID_VNM.Core.Scenes;
using SOLID_VNM.Core.Scenes.TextScene;
using Zenject;
using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Core
{
    public interface IScenePlayer
    {
        void Play();
        void End();
    }

    public class ScenePlayerDiscriminator : ISceneDefinitionVisitor
    {
        readonly private LazyInject<TextScenePlayer> _textScenePlayer;
        readonly private LazyInject<ChoiceScenePlayer> _choiceScenePlayer;

        private IScenePlayer _scenePlayer;

        public ScenePlayerDiscriminator(LazyInject<TextScenePlayer> textSceneManager, LazyInject<ChoiceScenePlayer> choiceScenePlayer)
        {
            _textScenePlayer = textSceneManager;
            _choiceScenePlayer = choiceScenePlayer;
        }

        public IScenePlayer Choose(ISceneDefinition sceneDefinition)
        {
            sceneDefinition.Accept(this);
            return _scenePlayer;
        }

        void ISceneDefinitionVisitor.Accept(TextSceneDefinition textSceneDefinition)
        {
            _textScenePlayer.Value.TextSceneDefinition = textSceneDefinition;
            _scenePlayer = _textScenePlayer.Value;
        }

        void ISceneDefinitionVisitor.Accept(ChoiceSceneDefinition choiceSceneDefinition)
        {
            _choiceScenePlayer.Value.ChoiceSceneDefinition = choiceSceneDefinition;
            _scenePlayer = _choiceScenePlayer.Value;
        }
    }
}