using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SOLID_VNM.Displays;

namespace SOLID_VNM.Displays.ActorDisplay
{
    public enum ActorPosition
    {
        Left,
        Right
    }

    [Serializable]
    public class ActorDisplayContent : IDisplayContent
    {
        public ActorDisplayActor[] _actorDisplayActorContent;
    }

    [Serializable]
    public class ActorDisplayActor
    {
        public Sprite _sprite;
        public ActorPosition _actorPosition;
    }
}