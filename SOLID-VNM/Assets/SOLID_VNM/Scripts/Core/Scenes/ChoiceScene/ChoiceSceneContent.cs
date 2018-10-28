using System;

using UnityEngine;

namespace SOLID_VNM.Core.Scenes.ChoiceScene
{
    [Serializable]
    public class SceneContentChoice : SceneContent
    {
        public Sprite background;
        public string[] choices;


        public override void Accept(ISceneContentVisitor sceneContentVisitor)
        {
            sceneContentVisitor.Visit(this);
        }
    }
}