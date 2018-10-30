using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SOLID_VNM.Displays.ChoiceDisplay
{
    public interface IChoiceDisplay : IDisplay<ChoiceDisplayContent> { }

    public class ChoiceDisplayController : IChoiceDisplay, IInitializable
    {
        private readonly ChoiceDisplayView _choiceDisplayView;

        public ChoiceDisplayController(ChoiceDisplayView choiceDisplayView)
        {
            _choiceDisplayView = choiceDisplayView;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        void IDisplay<ChoiceDisplayContent>.Display(ChoiceDisplayContent choiceDisplayContent)
        {
            _choiceDisplayView.Display(choiceDisplayContent);
        }

        void IDisplay<ChoiceDisplayContent>.Hide()
        {
            Hide();
        }

        private void Hide()
        {
            _choiceDisplayView.Hide();
        }
    }
}
