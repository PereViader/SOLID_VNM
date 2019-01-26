using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SOLID_VNM;
using SOLID_VNM.Scenes;

namespace SOLID_VNM
{
    public class Core
    {
        private readonly SceneControllerSelectorFactory _sceneControllerFactorySelector;
        private readonly SceneSelectorFactory _sceneFactory;

        private SceneController _sceneController;

        public Core(
            SceneControllerSelectorFactory sceneControllerFactorySelector,
            SceneSelectorFactory sceneFactory)
        {
            _sceneControllerFactorySelector = sceneControllerFactorySelector;
            _sceneFactory = sceneFactory;
        }

        public void Play(VisualNovelGraph dialogueNodeGraph)
        {
            Scene scene = _sceneFactory.Create(dialogueNodeGraph.RootNode);
            Play(scene);
        }

        public void Play(Scene scene)
        {
            if (_sceneController != null)
            {
                _sceneController.End();
            }

            _sceneController = _sceneControllerFactorySelector.Create(scene);
            _sceneController.Play();
        }
    }
}