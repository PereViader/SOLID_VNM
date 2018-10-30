using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Zenject;
using ModestTree;

namespace SOLID_VNM.Displays.ImageDisplay
{
    public interface IImageDisplay : IDisplay<ImageDisplayContent> { }

    public class ImageDisplayController : IImageDisplay, IInitializable
    {
        private readonly ImageDisplayView _imageDisplayView;

        public ImageDisplayController(ImageDisplayView imageDisplayView)
        {
            _imageDisplayView = imageDisplayView;
        }

        void IInitializable.Initialize()
        {
            Hide();
        }

        void IDisplay<ImageDisplayContent>.Display(ImageDisplayContent imageDisplayContent)
        {
            _imageDisplayView.Display(imageDisplayContent);
        }

        void IDisplay<ImageDisplayContent>.Hide()
        {
            Hide();
        }

        private void Hide()
        {
            _imageDisplayView.Hide();
        }
    }
}
