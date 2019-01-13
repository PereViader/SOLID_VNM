using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SOLID_VNM.Graph
{
    public interface INode
    {
        void Accept(INodeVisitor visitor);
    }

    public interface INodeVisitor
    {
        void Visit(IDialogueNode textNode);
        void Visit(IChoiceNode choiceNode);
    }
}

