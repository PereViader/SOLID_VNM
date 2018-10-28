using System;

using UnityEngine;

namespace SOLID_VNM.Core.Scenes.TextScene
{
    [Serializable]
    public class SceneContentDialogue : SceneContent
    {
        public int actorId;
        public string actorAction;
        public string text;
        public Sprite background;

        public override void Accept(ISceneContentVisitor sceneContentVisitor)
        {
            sceneContentVisitor.Visit(this);
        }
    }
}