using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using ModestTree;

using SOLID_VNM.Core.Scenes.TextScene;
using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public class BackgroundDisplayContentExtractor : ISceneContentVisitor
    {
        readonly private BackgroundDisplayContent.Factory _factory;

        private BackgroundDisplayContent _backgroundDisplayContent;

        public BackgroundDisplayContentExtractor(BackgroundDisplayContent.Factory factory)
        {
            _factory = factory;
        }

        public BackgroundDisplayContent Extract(SceneContent sceneContent)
        {
            Assert.IsNotNull(sceneContent);
            sceneContent.Accept(this);
            return _backgroundDisplayContent;
        }

        public void Visit(SceneContentDialogue sceneContentDialogue)
        {
            _backgroundDisplayContent = _factory.Create(sceneContentDialogue.background);
        }

        public void Visit(SceneContentChoice sceneContentChoice)
        {
            _backgroundDisplayContent = _factory.Create(sceneContentChoice.background);
        }
    }
}
