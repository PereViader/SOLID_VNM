using UnityEngine;
using XNode;

using SOLID_VNM.Actors;

namespace SOLID_VNM.Scenes.Dialogue
{
    public class XNodeDialogueNode : Node, XNodeSceneNode
    {
        [Input]
        public Node previous;

        [Output(backingValue = ShowBackingValue.Never, connectionType = ConnectionType.Override)]
        public Node next;

        [SerializeField]
        private XNodeDialogueModel _model;

        public XNodeDialogueModel Model { get { return _model; } }

        public XNodeSceneNode NextNode { get { return (XNodeSceneNode)this.GetOutputConnection("next"); } }

        public void Visit(XNodeSceneNodeVisitor visitor)
        {
            visitor.Accept(this);
        }
    }


    [System.Serializable]
    public class XNodeDialogueModel : XNodeSceneModel
    {
        public ScriptableObjectActor actor;
        public string text;
        public Sprite background;
    }
}