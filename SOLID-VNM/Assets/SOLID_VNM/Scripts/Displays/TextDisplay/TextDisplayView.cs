using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using ModestTree;
using Zenject;

namespace SOLID_VNM.Displays.TextDisplay
{
    public class TextDisplayView : MonoBehaviour, IInitializable
    {
        [SerializeField]
        private TMP_Text _guiText;

        [SerializeField]
        private TMP_Text _guiActorText;

        [SerializeField]
        private GameObject _textPanel;

        private void OnValidate()
        {
            Debug.Assert(_guiText != null, "gui Text in text display view is not assigned", this);
            Debug.Assert(_textPanel != null, "TextPanel gameobject in text display view is not assigned", this);
        }

        public void Initialize()
        {
            Hide();
        }

        public void Hide()
        {
            _textPanel.SetActive(false);
        }

        public void Display(TextDisplayContent textDisplayContent)
        {
            Assert.IsNotNull(textDisplayContent);

            _textPanel.SetActive(true);
            _guiText.text = textDisplayContent.Text;
            _guiActorText.text = textDisplayContent.ActorName;
        }
    }
}