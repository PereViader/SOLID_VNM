using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using ModestTree;
using Zenject;

using SOLID_VNM.Displays;
using SOLID_VNM.Actors;

namespace SOLID_VNM.Displays.ActorDisplay
{
    public interface IActorDisplay : IDisplay<IActorDisplayModel> { }

    public class ConcreteActorDisplay : IActorDisplay, IInitializable
    {
        private readonly IActorDisplayBehaviour _actorDisplayBehaviour;

        public ConcreteActorDisplay(IActorDisplayBehaviour actorDisplayBehaviour)
        {
            _actorDisplayBehaviour = actorDisplayBehaviour;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        void IDisplay<IActorDisplayModel>.Display(IActorDisplayModel model)
        {
            _actorDisplayBehaviour.Update(model);
            _actorDisplayBehaviour.Display(true);
        }

        void IDisplay<IActorDisplayModel>.Hide()
        {
            Hide();
        }

        private void Hide()
        {
            _actorDisplayBehaviour.Display(false);
        }
    }
}