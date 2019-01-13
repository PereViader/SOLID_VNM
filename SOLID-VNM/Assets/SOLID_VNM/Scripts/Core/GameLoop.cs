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
        private readonly SceneControllerFactory _sceneControllerFactory;
        private readonly SceneFactory _sceneFactory;

        private ISceneController _sceneController;

        public GameLoop(
            SceneControllerFactory sceneControllerFactory,
            SceneFactory sceneFactory)
        {
            _sceneControllerFactory = sceneControllerFactory;
            _sceneFactory = sceneFactory;
        }

        public void Play(IVisualNovelGraph dialogueNodeGraph)
        {
            IScene scene = _sceneFactory.Create(dialogueNodeGraph.RootNode);
            Play(scene);
        }

        public void Play(IScene scene)
        {
            if (_sceneController != null)
            {
                _sceneController.End();
            }

            _sceneController = _sceneControllerFactory.Create(scene);
            _sceneController.Play();
        }
    }
}