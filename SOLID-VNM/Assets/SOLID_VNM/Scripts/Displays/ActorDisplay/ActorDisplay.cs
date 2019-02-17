using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using ModestTree;
using Zenject;

using SOLID_VNM.Displays;
using SOLID_VNM.Actors;

namespace SOLID_VNM.Displays.ActorDisplay
{
    public interface ActorDisplay : Display<ActorDisplayContent> { }

    public class ActorDisplayImp : ActorDisplay, IInitializable
    {
        private readonly ActorDisplayBehaviour _actorDisplayBehaviour;

        public ActorDisplayImp(ActorDisplayBehaviour actorDisplayBehaviour)
        {
            _actorDisplayBehaviour = actorDisplayBehaviour;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        void Display<ActorDisplayContent>.Display(ActorDisplayContent content)
        {
            _actorDisplayBehaviour.Display(content);
            _actorDisplayBehaviour.Show();
        }

        void Display<ActorDisplayContent>.Hide()
        {
            Hide();
        }

        private void Hide()
        {
            _actorDisplayBehaviour.Hide();
        }
    }
}