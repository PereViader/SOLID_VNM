using System;
using UnityEngine;

using SOLID_VNM.Actors;
using SOLID_VNM.Core.Scenes.DialogueScene;
using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM
{
    public interface ISceneModelVisitor
    {
        void Visit(IDialogueSceneModel dialogueSceneModel);
        void Visit(IChoiceSceneModel choiceSceneModel);
    }

    public interface ISceneModel
    {
        void Accept(ISceneModelVisitor sceneContentVisitor);
    }
}
