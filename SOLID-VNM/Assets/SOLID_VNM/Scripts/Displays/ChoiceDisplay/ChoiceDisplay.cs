﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SOLID_VNM.Displays.ChoiceDisplay
{
    public interface ChoiceDisplay : Display<ChoiceDisplayContent> { }

    public class ConcreteChoiceDisplay : ChoiceDisplay, IInitializable
    {
        private readonly ChoiceDisplayView _choiceDisplayView;

        public ConcreteChoiceDisplay(ChoiceDisplayView choiceDisplayView)
        {
            _choiceDisplayView = choiceDisplayView;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        void Display<ChoiceDisplayContent>.Display(ChoiceDisplayContent choiceDisplayContent)
        {
            _choiceDisplayView.Display(choiceDisplayContent);
        }

        void Display<ChoiceDisplayContent>.Hide()
        {
            Hide();
        }

        private void Hide()
        {
            _choiceDisplayView.Hide();
        }
    }
}
