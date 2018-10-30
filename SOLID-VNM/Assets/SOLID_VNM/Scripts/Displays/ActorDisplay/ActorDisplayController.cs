using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SOLID_VNM.Displays;
using Zenject;

namespace SOLID_VNM.Displays.ActorDisplay
{
    public interface IActorDisplay : IDisplay<ActorDisplayContent> { }

    public class ActorDisplayController : IActorDisplay, IInitializable
    {
        private readonly ActorDisplayView _actorDisplayView;

        public ActorDisplayController(ActorDisplayView actorDisplayView)
        {
            _actorDisplayView = actorDisplayView;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        void IDisplay<ActorDisplayContent>.Display(ActorDisplayContent content)
        {
            _actorDisplayView.Display(content);
        }

        void IDisplay<ActorDisplayContent>.Hide()
        {
            Hide();
        }

        private void Hide()
        {
            _actorDisplayView.Hide();
        }
    }
}