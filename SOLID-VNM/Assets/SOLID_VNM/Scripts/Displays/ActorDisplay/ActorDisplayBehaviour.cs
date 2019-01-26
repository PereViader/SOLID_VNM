using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Actors;
using SOLID_VNM.Displays.ActorDisplay;
using System;

public interface ActorDisplayBehaviour
{
    void Update(ActorDisplayContent content);
    void Display(bool value);
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

    void ActorDisplayBehaviour.Update(ActorDisplayContent content)
    {
        CleanUpActors();

        foreach (var actor in content.Actors)
        {
            ActorDisplayActorView displayActor = CreateDisplayActorAtPosition(content.ActorPosition(actor));
            UpdateActorDisplayVisuals(displayActor, actor);
            _actorToDisplayActor.Add(actor, displayActor);
        }
    }

    private void UpdateActorDisplayVisuals(ActorDisplayActorView displayActor, Actor actor)
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
        instance.transform.SetParent(GetPositionParent(actorPosition), false);
        ActorDisplayActorView actorDisplayActorFacade = instance.GetComponent<ActorDisplayActorView>();
        _displayActorsInPosition[actorPosition].Add(actorDisplayActorFacade);
        return actorDisplayActorFacade;
    }

    private Transform GetPositionParent(ActorPosition actorPosition)
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

    void ActorDisplayBehaviour.Display(bool value)
    {
        _actorDisplayView.display.SetActive(value);
    }

    [System.Serializable]
    public class Settings
    {
        public GameObject actorDisplayActorPrefab;
    }
}