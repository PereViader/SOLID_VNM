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

        private IChoiceHandler _choiceHandler;

        private ChoiceDisplayContent.Choice _choice;

        [Inject]
        private void Init(/*IChoiceHandler choiceHandler*/)
        {
            //_choiceHandler = choiceHandler;
        }

        private void Awake()
        {
            _button.onClick.AddListener(OnButtonPressed);
        }

        public void SetChoice(ChoiceDisplayContent.Choice choice)
        {
            _choice = choice;
            _text.SetText(choice.text);
        }

        public void OnButtonPressed()
        {
            Assert.IsNotNull(_choice);

            Debug.Log(_choice.text);
            _choiceHandler.OnChoiceSelected(0); //@TODO: send the actual ID

        }
    }
}

