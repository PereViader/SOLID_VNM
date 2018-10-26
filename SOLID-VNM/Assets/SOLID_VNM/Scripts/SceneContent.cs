using System;
using UnityEngine;

using SOLID_VNM.Actors;

namespace SOLID_VNM
{
    public interface ISceneContentVisitor
    {
        void Visit(SceneContentDialogue sceneContentDialogue);
    }

    public abstract class SceneContent
    {
        public abstract void Accept(ISceneContentVisitor sceneContentVisitor);
    }

    [System.Serializable]
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
