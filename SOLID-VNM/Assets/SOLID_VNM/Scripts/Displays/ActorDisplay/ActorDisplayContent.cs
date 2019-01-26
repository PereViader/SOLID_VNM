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

    public interface ActorDisplayContent : DisplayContent
    {
        List<Actor> Actors { get; }
        ActorPosition ActorPosition(Actor actor);
        List<Actor> ActorsAtPosition(ActorPosition position);
    }

    public class ActorDisplayContentImpl : ActorDisplayContent
    {
        private List<Actor> _actors = new List<Actor>();
        private Dictionary<ActorPosition, List<Actor>> _actorsAtPosition = new Dictionary<ActorPosition, List<Actor>>();
        private Dictionary<Actor, ActorPosition> _actorPositions = new Dictionary<Actor, ActorPosition>();

        public ActorDisplayContentImpl(List<Actor> leftActors, List<Actor> rightActors)
        {
            _actors.AddRange(leftActors);
            _actors.AddRange(rightActors);

            _actorsAtPosition.Add(ActorPosition.Left, leftActors);
            _actorsAtPosition.Add(ActorPosition.Right, rightActors);


            foreach (Actor actor in leftActors)
            {
                _actorPositions.Add(actor, ActorPosition.Left);
            }

            foreach (Actor actor in rightActors)
            {
                _actorPositions.Add(actor, ActorPosition.Right);
            }
        }

        List<Actor> ActorDisplayContent.Actors { get { return _actors; } }

        ActorPosition ActorDisplayContent.ActorPosition(Actor actor)
        {
            return _actorPositions[actor];
        }

        List<Actor> ActorDisplayContent.ActorsAtPosition(ActorPosition position)
        {
            return _actorsAtPosition[position];
        }

        public class Factory : PlaceholderFactory<List<Actor>, List<Actor>, ActorDisplayContentImpl> { }
    }
}