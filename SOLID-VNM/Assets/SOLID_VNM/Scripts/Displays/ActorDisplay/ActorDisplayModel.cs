using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Zenject;

using SOLID_VNM.Actors;
using SOLID_VNM.Displays;

namespace SOLID_VNM.Displays.ActorDisplay
{
    public enum ActorPosition
    {
        Left,
        Right,
    }

    public enum ActorState
    {
        Hidden,
        Silent,
        Talking
    }

    public interface IActorDisplayModel : IDisplayModel
    {
        //Ordered Left to right
        List<IActor> Actors { get; }
        ActorPosition GetActorPosition(IActor actor);
        int GetActorPositionIndex(IActor actor);
        List<IActor> GetActorsInPosition(ActorPosition position);
        //ActorState GetActorState(IActor actor);
    }

    public class ConcreteActorDisplayModel : IActorDisplayModel
    {
        private List<IActor> _actors = new List<IActor>();
        private Dictionary<ActorPosition, List<IActor>> _actorsInPosition = new Dictionary<ActorPosition, List<IActor>>();
        private Dictionary<IActor, ActorPosition> _actorPositions = new Dictionary<IActor, ActorPosition>();

        //private Dictionary<IActor, ActorState> _actorStates = new Dictionary<IActor, ActorState>();

        public ConcreteActorDisplayModel(List<IActor> leftActors, List<IActor> rightActors)
        {
            _actors.AddRange(leftActors);
            _actors.AddRange(rightActors);

            _actorsInPosition.Add(ActorPosition.Left, leftActors);
            _actorsInPosition.Add(ActorPosition.Right, rightActors);


            foreach (IActor actor in leftActors)
            {
                _actorPositions.Add(actor, ActorPosition.Left);
            }

            foreach (IActor actor in rightActors)
            {
                _actorPositions.Add(actor, ActorPosition.Right);
            }
        }

        List<IActor> IActorDisplayModel.Actors { get { return _actors; } }

        ActorPosition IActorDisplayModel.GetActorPosition(IActor actor)
        {
            return _actorPositions[actor];
        }

        int IActorDisplayModel.GetActorPositionIndex(IActor actor)
        {
            return _actorsInPosition[_actorPositions[actor]].IndexOf(actor);
        }

        /*
        public ActorState GetActorState(IActor actor)
        {
            return _actorStates[actor];
        }
        */

        List<IActor> IActorDisplayModel.GetActorsInPosition(ActorPosition position)
        {
            return _actorsInPosition[position];
        }

        public class Factory : PlaceholderFactory<List<IActor>, List<IActor>, ConcreteActorDisplayModel> { }
    }
}