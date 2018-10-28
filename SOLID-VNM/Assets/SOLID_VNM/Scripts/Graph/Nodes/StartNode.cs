using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace SOLID_VNM.Graph
{
    public class StartNode : Node
    {
        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override)]
        public VNNode next;

        public VNNode Start
        {
            get
            {
                return this.GetOutputConnection<VNNode>("next");
            }
        }

        public override object GetValue(NodePort port)
        {
            return null;
        }
    }
}