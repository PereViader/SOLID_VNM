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
        private readonly SceneControllerDiscriminator _sceneControllerDiscriminator;
        private readonly SceneFactory _sceneFactory;

        private ISceneController _sceneController;

        public GameLoop(SceneControllerDiscriminator sceneControllerDiscriminator, SceneFactory sceneFactory)
        {
            _sceneControllerDiscriminator = sceneControllerDiscriminator;
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

            _sceneController = _sceneControllerDiscriminator.Choose(scene);
            _sceneController.Play();
        }
    }
}