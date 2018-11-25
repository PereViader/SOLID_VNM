using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Actors;
using SOLID_VNM.Displays.ActorDisplay;
using System;

public interface IActorDisplayBehaviour
{
    void Update(IActorDisplayModel model);
    void Display(bool value);
}

public class SimpleActorDisplayBehaviour : IActorDisplayBehaviour
{
    private readonly ActorDisplayView _actorDisplayFacade;
    private readonly Settings _settings;

    private Dictionary<ActorPosition, List<ActorDisplayActorView>> _displayActorsInPosition = new Dictionary<ActorPosition, List<ActorDisplayActorView>>();
    private Dictionary<IActor, ActorDisplayActorView> _actorToDisplayActor = new Dictionary<IActor, ActorDisplayActorView>();

    public SimpleActorDisplayBehaviour(ActorDisplayView actorDisplayFacade, Settings settings)
    {
        _actorDisplayFacade = actorDisplayFacade;
        _settings = settings;

        foreach (ActorPosition actorPosition in System.Enum.GetValues(typeof(ActorPosition)))
        {
            _displayActorsInPosition.Add(actorPosition, new List<ActorDisplayActorView>());
        }
    }

    void IActorDisplayBehaviour.Update(IActorDisplayModel model)
    {
        CleanUpActors();

        foreach (var actor in model.Actors)
        {
            ActorDisplayActorView displayActor = CreateDisplayActorAtPosition(model.GetActorPosition(actor));
            UpdateActorDisplayVisuals(displayActor, actor);
            _actorToDisplayActor.Add(actor, displayActor);
        }
    }

    private void UpdateActorDisplayVisuals(ActorDisplayActorView displayActor, IActor actor)
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
                return _actorDisplayFacade.leftActorRoot.transform;
            case ActorPosition.Right:
                return _actorDisplayFacade.rightActorsRoot.transform;
            default:
                throw new System.ApplicationException("This should never happen");
        }
    }

    void IActorDisplayBehaviour.Display(bool value)
    {
        _actorDisplayFacade.display.SetActive(value);
    }

    [System.Serializable]
    public class Settings
    {
        public GameObject actorDisplayActorPrefab;
    }
}