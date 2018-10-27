using System;
using UnityEngine;

using SOLID_VNM.Actors;
using SOLID_VNM.Core.Scenes.TextScene;
using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM
{
    public interface ISceneContentVisitor
    {
        void Visit(SceneContentDialogue sceneContentDialogue);
        void Visit(SceneContentChoice sceneContentChoice);
    }

    public abstract class SceneContent
    {
        public abstract void Accept(ISceneContentVisitor sceneContentVisitor);
    }
}
