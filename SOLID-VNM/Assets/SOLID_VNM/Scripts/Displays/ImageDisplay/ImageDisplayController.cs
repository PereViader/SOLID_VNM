using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Zenject;
using ModestTree;

namespace SOLID_VNM.Displays.ImageDisplay
{
    public interface IImageDisplay : IDisplay<ImageDisplayContent> { }

    public class ImageDisplayController : IImageDisplay
    {
        readonly private ImageDisplayView _imageDisplayView;

        public ImageDisplayController(ImageDisplayView imageDisplayView)
        {
            _imageDisplayView = imageDisplayView;
        }

        void IDisplay<ImageDisplayContent>.Hide()
        {
            _imageDisplayView.Hide();
        }

        void IDisplay<ImageDisplayContent>.Display(ImageDisplayContent imageDisplayContent)
        {
            _imageDisplayView.Display(imageDisplayContent);
        }
    }
}
