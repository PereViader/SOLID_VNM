using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace SOLID_VNM.Displays.ActorDisplay
{
    public class ActorDisplayView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _actorDisplay;

        [SerializeField]
        private Image _leftActor;

        [SerializeField]
        private Image _rightActor;


        public void Display(ActorDisplayContent actorDisplayContent)
        {
            foreach (ActorDisplayActor actor in actorDisplayContent._actorDisplayActorContent)
            {
                PlaceActor(actor);
            }
        }

        public void Hide()
        {
            _leftActor.sprite = null;
            _rightActor.sprite = null;
        }

        private void PlaceActor(ActorDisplayActor actor)
        {
            Image image = null;

            switch (actor._actorPosition)
            {
                case ActorPosition.Left:
                    image = _leftActor;
                    break;
                case ActorPosition.Right:
                    image = _rightActor;
                    break;
                default:
                    Debug.LogError("This should never happen");
                    break;
            }

            if (image.sprite != null)
            {
                Debug.LogError("There is already a sprite on the actor");
            }

            image.sprite = actor._sprite;
        }
    }
}