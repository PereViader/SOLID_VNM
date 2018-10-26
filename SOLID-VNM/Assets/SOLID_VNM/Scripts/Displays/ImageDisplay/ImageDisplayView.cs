using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SOLID_VNM.Displays.ImageDisplay
{
    public class ImageDisplayView : MonoBehaviour, IImageDisplayConentVisitor
    {
        [SerializeField]
        private Image _image;

        [SerializeField]
        private Animation _animation;

        public void Hide()
        {
            gameObject.SetActive(false);

            _image.enabled = false;
            _image.sprite = null;

            if (_animation.isPlaying)
                _animation.Stop();
        }

        public void Display(ImageDisplayContent imageContent)
        {
            Debug.Assert(imageContent != null);
            imageContent.Accept(this);
        }

        public void Display(ImageDisplayConentSprited imageConentSprited)
        {
            DisplayImpl(imageConentSprited.Sprite, null);
        }

        public void Display(ImageDisplayConentSpritedAnimated imageConentSpritedAnimated)
        {
            DisplayImpl(imageConentSpritedAnimated.Sprite, imageConentSpritedAnimated.AnimationClip);
        }

        private void DisplayImpl(Sprite sprite, AnimationClip animationClip)
        {
            gameObject.SetActive(true);
            if (sprite != null)
            {
                _image.enabled = true;
                _image.sprite = sprite;

                if (animationClip != null)
                {
                    _animation.clip = animationClip;
                    _animation.Play();
                }
            }
        }

        void IImageDisplayConentVisitor.VisitImageDisplayConentSprited(ImageDisplayConentSprited imageConentSprited)
        {
            Display(imageConentSprited);
        }

        void IImageDisplayConentVisitor.VisitImageDisplayConentSpritedAnimated(ImageDisplayConentSpritedAnimated imageConentSpritedAnimated)
        {
            Display(imageConentSpritedAnimated);
        }
    }
}
