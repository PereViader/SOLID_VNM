using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SOLID_VNM.Dialogue
{
    public class DialogueStartNode : Node
    {
        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override)]
        public DialogueNode next;

        public DialogueNode Start
        {
            get
            {
                return this.GetOutputConnection<DialogueNode>("next");
            }
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}