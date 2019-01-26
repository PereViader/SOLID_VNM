using System;
using UnityEngine;

using SOLID_VNM.Actors;
using SOLID_VNM.Scenes.Dialogue;
using SOLID_VNM.Scenes.Choice;

namespace SOLID_VNM.Scenes
{
    public interface SceneModelVisitor
    {
        void Visit(DialogueSceneModel dialogueSceneModel);
        void Visit(ChoiceSceneModel choiceSceneModel);
    }

    public interface SceneModel
    {
        void Accept(SceneModelVisitor sceneContentVisitor);
    }
}
