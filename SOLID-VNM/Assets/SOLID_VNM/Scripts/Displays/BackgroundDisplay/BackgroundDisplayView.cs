using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public class BackgroundDisplayView : MonoBehaviour
    {
        [SerializeField]
        private Image _guiImage;

        [SerializeField]
        private GameObject _backgroundCanvas;

        public Image CanvasImage { get { return _guiImage; } }

        public GameObject Canvas { get { return _backgroundCanvas; } }

        private void OnValidate()
        {
            Debug.Assert(_backgroundCanvas != null, "BackgroundDisplayView: Background Canvas is not assigned", this);
            Debug.Assert(_guiImage != null, "BackgroundDisplayView: Image is not assigned", this);
        }
    }
}

