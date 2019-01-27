using System.Linq;

using UnityEngine;
using XNode;


namespace SOLID_VNM.Scenes.Choice
{
    [CreateNodeMenu("SOLID VNM/Choice Node")]
    public class XNodeChoiceNode : Node, XNodeSceneNode
    {
        [Input]
        public Node previous;

        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Multiple)]
        public Node choices;


        [SerializeField]
        private XNodeChoiceModel _model;

        public XNodeChoiceModel Model { get { return _model; } }
        public XNodeSceneNode[] Choices { get { return this.GetOutputConnections("choices").Select(choice => (XNodeSceneNode)choice).ToArray(); } }

        public void Visit(XNodeSceneNodeVisitor visitor)
        {
            visitor.Accept(this);
        }
    }

    [System.Serializable]
    public class XNodeChoiceModel : XNodeSceneModel
    {
        public Sprite background;
        public string[] choices;
    }
}