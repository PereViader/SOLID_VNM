using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using XNode;

using SOLID_VNM.Actors;

namespace SOLID_VNM.Scenes.Dialogue
{
    [CreateNodeMenu("SOLID VNM/Dialogue Node")]
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
        public ScriptableObjectActor mainActor;
        public List<ActorInPosition> actors;

        public string text;
        public Sprite background;


        [System.Serializable]
        public class ActorInPosition
        {
            public ScriptableObjectActor actor;
            public ActorPosition actorPosition;
        }
    }
}