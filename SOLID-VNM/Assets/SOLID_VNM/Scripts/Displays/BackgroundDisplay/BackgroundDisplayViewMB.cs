using UnityEngine;
using UnityEngine.UI;

namespace SOLID_VNM.Displays.BackgroundDisplay
{
    public class BackgroundDisplayViewMB : MonoBehaviour
    {
        [SerializeField]
        private GameObject _backgroundDisplay;


        [SerializeField]
        private Image _startingFrontBackgroundImage;

        [SerializeField]
        private Image _startingBackBackgroundImage;

        public GameObject Canvas { get { return _backgroundDisplay; } }
        public Image StartingFrontBackground { get { return _startingFrontBackgroundImage; } }
        public Image StartingBackBackground { get { return _startingBackBackgroundImage; } }

        private void OnValidate()
        {
            Debug.Assert(_backgroundDisplay != null, "BackgroundDisplayView: Background Display is not assigned", this);
            Debug.Assert(_startingFrontBackgroundImage != null, "BackgroundDisplayView: Staring Front Background Image is not assigned", this);
            Debug.Assert(_startingBackBackgroundImage != null, "BackgroundDisplayView: Staring Back Background Image is not assigned", this);
        }
    }
}
