using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SOLID_VNM.Graph
{
    public class StartNode : Node
    {
        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override)]
        public BaseNode next;

        public INode Start
        {
            get
            {
                return (INode)this.GetOutputConnection("next");
            }
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}