using UnityEngine;
using XNode;

namespace SOLID_VNM.Graph.XNode
{
    public class StartNode : Node
    {
        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override)]
        public Node next;

        public IGraphNode Start
        {
            get
            {
                return (IGraphNode)this.GetOutputConnection("next");
            }
        }
    }
}