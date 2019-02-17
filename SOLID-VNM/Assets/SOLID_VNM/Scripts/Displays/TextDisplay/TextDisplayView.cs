using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using ModestTree;
using Zenject;

namespace SOLID_VNM.Displays.TextDisplay
{
    public class TextDisplayView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _guiText;

        [SerializeField]
        private TMP_Text _guiActorText;

        [SerializeField]
        private GameObject _textPanel;

        public TMP_Text ContentText { get { return _guiText; } }
        public TMP_Text ActorText { get { return _guiActorText; } }
        public GameObject Canvas { get { return _textPanel; } }


        private void OnValidate()
        {
            Debug.Assert(_guiText != null, "gui Text in text display view is not assigned", this);
            Debug.Assert(_textPanel != null, "TextPanel gameobject in text display view is not assigned", this);
        }
    }
}