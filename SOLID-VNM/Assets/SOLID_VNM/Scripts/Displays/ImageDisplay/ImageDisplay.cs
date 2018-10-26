using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Zenject;
using ModestTree;

namespace SOLID_VNM.Displays.ImageDisplay
{
    public class ImageDisplayController : IDisplay
    {
        readonly private ImageDisplayView _imageDisplayView;
        readonly private ImageDisplayContentExtractor _imageDisplayContentFactory;

        public ImageDisplayController(ImageDisplayView imageDisplayView, ImageDisplayContentExtractor imageDisplayContentFactory)
        {
            _imageDisplayView = imageDisplayView;
            _imageDisplayContentFactory = imageDisplayContentFactory;
        }

        void IDisplay.Hide()
        {
            _imageDisplayView.Hide();
        }

        void IDisplay.Display(SceneContent sceneContent)
        {
            using (ImageDisplayContent imageDisplayContent = _imageDisplayContentFactory.Create(sceneContent)) // We request an instance and then dispose of it
            {
                _imageDisplayView.Display(imageDisplayContent);
            }
        }
    }
}
