using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

using SOLID_VNM.Scenes.Choice;
using SOLID_VNM.Scenes.Dialogue;


namespace SOLID_VNM.Scenes
{
    public interface SceneNode
    {
        void Accept(SceneNodeVisitor visitor);
    }

    public interface SceneNodeVisitor
    {
        void Visit(DialogueNode textNode);
        void Visit(ChoiceNode choiceNode);
    }
}

