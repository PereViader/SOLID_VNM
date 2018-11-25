using UnityEngine;
using UnityEngine.UI;

using Zenject;

namespace SOLID_VNM.Displays.ActorDisplay
{
    public class ActorDisplayActorView : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        public Image Image { get { return _image; } }
    }
}