using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Actors;
using SOLID_VNM.Displays.ActorDisplay;
using System;

namespace SOLID_VNM.Displays.ActorDisplay
{
    public interface ActorDisplayBehaviour
    {
        void Display(ActorDisplayContent content);
        void Show();
        void Hide();
    }

    public class SimpleActorDisplayBehaviour : ActorDisplayBehaviour
    {
        private readonly ActorDisplayView _actorDisplayView;
        private readonly Settings _settings;

        private Dictionary<ActorPosition, List<ActorDisplayActorView>> _displayActorsInPosition = new Dictionary<ActorPosition, List<ActorDisplayActorView>>();
        private Dictionary<Actor, ActorDisplayActorView> _actorToDisplayActor = new Dictionary<Actor, ActorDisplayActorView>();

        public SimpleActorDisplayBehaviour(ActorDisplayView actorDisplayView, Settings settings)
        {
            _actorDisplayView = actorDisplayView;
            _settings = settings;

            foreach (ActorPosition actorPosition in System.Enum.GetValues(typeof(ActorPosition)))
            {
                _displayActorsInPosition.Add(actorPosition, new List<ActorDisplayActorView>());
            }
        }

        void ActorDisplayBehaviour.Display(ActorDisplayContent content)
        {
            CleanUpActors();

            foreach (Actor actor in content.Actors)
            {
                ActorPosition actorPosition = content.ActorPosition(actor);
                ActorDisplayActorView displayActor = CreateDisplayActorAtPosition(actorPosition);
                InitializeActorDisplayActorView(displayActor, actor);
                _actorToDisplayActor.Add(actor, displayActor);
            }
        }

        private void InitializeActorDisplayActorView(ActorDisplayActorView displayActor, Actor actor)
        {
            displayActor.Image.sprite = actor.Sprite;
        }

        private void CleanUpActors()
        {
            foreach (ActorDisplayActorView actor in _actorToDisplayActor.Values)
            {
                GameObject.Destroy(actor.gameObject);
            }

            _actorToDisplayActor.Clear();
            foreach (var actorList in _displayActorsInPosition.Values)
            {
                actorList.Clear();
            }
        }

        private ActorDisplayActorView CreateDisplayActorAtPosition(ActorPosition actorPosition)
        {
            GameObject instance = GameObject.Instantiate(_settings.actorDisplayActorPrefab);
            instance.transform.SetParent(GetParentForPosition(actorPosition), false);
            ActorDisplayActorView actorDisplayActorFacade = instance.GetComponent<ActorDisplayActorView>();
            _displayActorsInPosition[actorPosition].Add(actorDisplayActorFacade);
            return actorDisplayActorFacade;
        }

        private Transform GetParentForPosition(ActorPosition actorPosition)
        {
            switch (actorPosition)
            {
                case ActorPosition.Left:
                    return _actorDisplayView.leftActorRoot.transform;
                case ActorPosition.Right:
                    return _actorDisplayView.rightActorsRoot.transform;
                default:
                    throw new System.ApplicationException("This should never happen");
            }
        }

        void ActorDisplayBehaviour.Show()
        {
            _actorDisplayView.display.SetActive(true);
        }

        void ActorDisplayBehaviour.Hide()
        {
            _actorDisplayView.display.SetActive(false);
        }

        [System.Serializable]
        public class Settings
        {
            public GameObject actorDisplayActorPrefab;
        }
    }
}