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
        private ChoiceDisplayButtonView[] _choiceButtonControllers;

        [SerializeField]
        private GameObject _choicePanel;


        public ChoiceDisplayButtonView[] ChoiceButtonControllers { get { return _choiceButtonControllers; } }
        public GameObject ChoicePanel { get { return _choicePanel; } }
    }
}