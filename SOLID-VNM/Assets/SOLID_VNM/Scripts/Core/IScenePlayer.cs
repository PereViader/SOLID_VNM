using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM;
using SOLID_VNM.GameBehaviour.Scenes;
using SOLID_VNM.GameBehaviour.Scenes.TextScene;
using Zenject;

namespace SOLID_VNM.GameBehaviour
{
    public interface IScenePlayer
    {
        void Play();
        void End();
    }

    public class ScenePlayerDiscriminator : ISceneDefinitionVisitor
    {
        readonly private LazyInject<TextScenePlayer> _textScenePlayer;

        private IScenePlayer _scenePlayer;

        public ScenePlayerDiscriminator(LazyInject<TextScenePlayer> textSceneManager)
        {
            _textScenePlayer = textSceneManager;
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
    }
}