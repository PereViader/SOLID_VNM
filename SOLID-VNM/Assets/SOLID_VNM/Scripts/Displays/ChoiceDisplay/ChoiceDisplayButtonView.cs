using UnityEngine;
using UnityEngine.UI;

using TMPro;
using Zenject;
using ModestTree;

namespace SOLID_VNM.Displays.ChoiceDisplay
{
    public class ChoiceDisplayButtonView : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private TMP_Text _text;

        public Button Button { get { return _button; } }
        public TMP_Text Text { get { return _text; } }
    }
}

