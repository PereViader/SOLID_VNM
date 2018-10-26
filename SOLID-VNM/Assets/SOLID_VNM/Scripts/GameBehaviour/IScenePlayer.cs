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
        readonly private LazyInject<TextSceneManager> _textSceneManager;

        private IScenePlayer _scenePlayer;

        public ScenePlayerDiscriminator(LazyInject<TextSceneManager> textSceneManager)
        {
            _textSceneManager = textSceneManager;
        }

        public IScenePlayer Choose(ISceneDefinition sceneDefinition)
        {
            sceneDefinition.Accept(this);
            return _scenePlayer;
        }

        void ISceneDefinitionVisitor.Accept(TextSceneDefinition textSceneDefinition)
        {
            _textSceneManager.Value.TextSceneDefinition = textSceneDefinition;
            _scenePlayer = _textSceneManager.Value;
        }
    }
}