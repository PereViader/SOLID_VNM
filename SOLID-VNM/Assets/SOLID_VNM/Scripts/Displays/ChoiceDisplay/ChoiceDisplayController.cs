using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SOLID_VNM.Displays.ChoiceDisplay
{
    public class ChoiceDisplayController : IDisplay, IInitializable
    {
        readonly private ChoiceDisplayContentExtractor _choiceDisplayContentExtractor;
        readonly private ChoiceDisplayView _choiceDisplayView;

        public ChoiceDisplayController(ChoiceDisplayView choiceDisplayView)
        {
            _choiceDisplayView = choiceDisplayView;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        public void Display(SceneContent sceneContent)
        {
            using (ChoiceDisplayContent choiceDisplayContent = _choiceDisplayContentExtractor.Extract(sceneContent))
            {
                _choiceDisplayView.Display(choiceDisplayContent);
            }
        }

        public void Hide()
        {
            _choiceDisplayView.Hide();
        }
    }
}
