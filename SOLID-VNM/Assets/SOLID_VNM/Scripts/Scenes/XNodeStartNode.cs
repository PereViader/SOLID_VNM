using UnityEngine;
using XNode;

namespace SOLID_VNM.Scenes
{
    public class StartNode : Node
    {
        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override)]
        public Node next;

        public XNodeSceneNode Start
        {
            get
            {
                return (XNodeSceneNode)this.GetOutputConnection("next");
            }
        }
    }
}