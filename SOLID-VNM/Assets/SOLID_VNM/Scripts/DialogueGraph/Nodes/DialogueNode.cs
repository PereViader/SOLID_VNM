using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SOLID_VNM.Dialogue
{
    public abstract class DialogueNode : Node
    {
        public override object GetValue(NodePort port)
        {
            return null;
        }

        public abstract void Accept(IDialogueNodeVisitor visitor);
    }

    public interface IDialogueNodeVisitor
    {
        void Accept(TextNode textNode);
    }
}

