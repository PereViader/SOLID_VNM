using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SOLID_VNM.Displays.ChoiceDisplay
{
    public interface ChoiceDisplay : Display<ChoiceDisplayContent> { }

    public class ChoiceDisplayImp : ChoiceDisplay, IInitializable
    {
        private readonly ChoiceDisplayView _choiceDisplayView;

        public ChoiceDisplayImp(ChoiceDisplayView choiceDisplayView)
        {
            _choiceDisplayView = choiceDisplayView;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        void Display<ChoiceDisplayContent>.Display(ChoiceDisplayContent choiceDisplayContent)
        {

            for (int i = 0; i < choiceDisplayContent.Choices.Length; i++)
            {
                ChoiceDisplayContent.Choice choice = choiceDisplayContent.Choices[i];
                ChoiceDisplayButtonView choiceButton = _choiceDisplayView.ChoiceButtonControllers[i];
                DisplayChoiceAtButton(choice, choiceButton);
                choiceButton.gameObject.SetActive(true);
            }

            _choiceDisplayView.ChoicePanel.SetActive(true);
        }

        private void DisplayChoiceAtButton(ChoiceDisplayContent.Choice choice, ChoiceDisplayButtonView choiceButton)
        {
            choiceButton.Text.text = choice.text;
        }

        void Display<ChoiceDisplayContent>.Hide()
        {
            Hide();
        }

        private void Hide()
        {
            _choiceDisplayView.ChoicePanel.SetActive(false);
            foreach (ChoiceDisplayButtonView choiceButton in _choiceDisplayView.ChoiceButtonControllers)
            {
                choiceButton.gameObject.SetActive(false);
            }
        }
    }
}
