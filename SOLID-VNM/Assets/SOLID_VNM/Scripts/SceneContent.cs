using System;
using UnityEngine;

using SOLID_VNM.Actors;
using SOLID_VNM.Core.Scenes.DialogueScene;
using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM
{
    public interface ISceneContentVisitor
    {
        void Visit(ConcreteDialogueSceneModel sceneContentDialogue);
        void Visit(IChoiceSceneModel sceneContentChoice);
    }

    public interface ISceneModel
    {
        void Accept(ISceneContentVisitor sceneContentVisitor);
    }
}
