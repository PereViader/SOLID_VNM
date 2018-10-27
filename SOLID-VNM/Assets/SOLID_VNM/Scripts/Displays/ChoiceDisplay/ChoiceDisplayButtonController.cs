using UnityEngine;
using UnityEngine.UI;

using TMPro;
using Zenject;
using ModestTree;

namespace SOLID_VNM.Displays.ChoiceDisplay
{
    public class ChoiceDisplayButtonController : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private TMP_Text _text;

        public void SetChoice(ChoiceDisplayContent.Choice choice)
        {
            _text.SetText(choice.text);
        }
    }
}

