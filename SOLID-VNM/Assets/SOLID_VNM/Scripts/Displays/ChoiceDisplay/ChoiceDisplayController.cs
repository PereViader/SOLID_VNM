using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SOLID_VNM.Displays.ChoiceDisplay
{
    public interface IChoiceDisplay : IDisplay<ChoiceDisplayContent> { }

    public class ChoiceDisplayController : IChoiceDisplay, IInitializable
    {
        readonly private ChoiceDisplayView _choiceDisplayView;

        public ChoiceDisplayController(ChoiceDisplayView choiceDisplayView)
        {
            _choiceDisplayView = choiceDisplayView;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        public void Display(ChoiceDisplayContent choiceDisplayContent)
        {
            _choiceDisplayView.Display(choiceDisplayContent);
        }

        public void Hide()
        {
            _choiceDisplayView.Hide();
        }
    }
}
