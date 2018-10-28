using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SOLID_VNM.Graph
{
    public interface ISolidNode
    {
    }


    public abstract class VNNode : Node
    {
        public override object GetValue(NodePort port)
        {
            return null;
        }

        public abstract void Accept(IDialogueNodeVisitor visitor);
    }

    public interface IDialogueNodeVisitor
    {
        void Accept(DialogueNode textNode);
        void Accept(ChoiceNode choiceNode);
    }
}

