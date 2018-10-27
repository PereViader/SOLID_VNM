using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SOLID_VNM;
using SOLID_VNM.Dialogue;

namespace SOLID_VNM.Core
{
    public class GameLoop
    {
        readonly private ScenePlayerDiscriminator _scenePlayerDiscriminator;
        readonly private SceneDefinitionFactory _sceneDefinitionFactory;

        private IScenePlayer _scenePlayer;

        public GameLoop(ScenePlayerDiscriminator scenePlayerDiscriminator, SceneDefinitionFactory sceneDefinitionFactory)
        {
            _scenePlayerDiscriminator = scenePlayerDiscriminator;
            _sceneDefinitionFactory = sceneDefinitionFactory;
        }

        public void Play(DialogueNodeGraph dialogueNodeGraph)
        {
            ISceneDefinition sceneDefinition = _sceneDefinitionFactory.Create(dialogueNodeGraph.RootNode);
            Play(sceneDefinition);
        }

        public void Play(ISceneDefinition sceneDefinition)
        {
            if (_scenePlayer != null)
            {
                _scenePlayer.End();
            }

            _scenePlayer = _scenePlayerDiscriminator.Choose(sceneDefinition);
            _scenePlayer.Play();
        }
    }
}