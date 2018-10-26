using System.Collections;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;

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

        private BackgroundDisplayContent Extract(SceneContentDialogue sceneContentDialogue)
        {
            return _factory.Create(sceneContentDialogue.background);
        }

        public void Visit(SceneContentDialogue sceneContentDialogue)
        {
            _backgroundDisplayContent = Extract(sceneContentDialogue);
        }
    }
}
