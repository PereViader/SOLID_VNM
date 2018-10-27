using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;
using ModestTree;

namespace SOLID_VNM.Displays.ChoiceDisplay
{
    public class ChoiceDisplayView : MonoBehaviour
    {
        [SerializeField]
        private ChoiceDisplayButtonController[] _choiceButtonControllers;

        [SerializeField]
        private GameObject _choicePanel;

        public void Initialize()
        {
            Hide();
        }

        public void Hide()
        {
            _choicePanel.SetActive(false);
        }

        public void Display(ChoiceDisplayContent choiceDisplayContent)
        {
            Assert.IsNotNull(choiceDisplayContent);
            Assert.IsEqual(_choiceButtonControllers.Length, choiceDisplayContent.Choices.Length);

            for (int i = 0; i < _choiceButtonControllers.Length; i++)
            {
                _choiceButtonControllers[i].SetChoice(choiceDisplayContent.Choices[i]);
            }
            _choicePanel.SetActive(true);
        }
    }
}