using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SOLID_VNM;
using SOLID_VNM.Graph;
using SOLID_VNM.Core.Scenes;

namespace SOLID_VNM.Core
{
    public class GameLoop
    {
        readonly private SceneControllerDiscriminator _sceneControllerDiscriminator;
        readonly private SceneDefinitionFactory _sceneDefinitionFactory;

        private ISceneController _sceneController;

        public GameLoop(SceneControllerDiscriminator sceneControllerDiscriminator, SceneDefinitionFactory sceneDefinitionFactory)
        {
            _sceneControllerDiscriminator = sceneControllerDiscriminator;
            _sceneDefinitionFactory = sceneDefinitionFactory;
        }

        public void Play(VNGraph dialogueNodeGraph)
        {
            ISceneDefinition sceneDefinition = _sceneDefinitionFactory.Create(dialogueNodeGraph.RootNode);
            Play(sceneDefinition);
        }

        public void Play(ISceneDefinition sceneDefinition)
        {
            if (_sceneController != null)
            {
                _sceneController.End();
            }

            _sceneController = _sceneControllerDiscriminator.Choose(sceneDefinition);
            _sceneController.Play();
        }
    }
}