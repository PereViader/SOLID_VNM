using System;
using ModestTree;
using UnityEngine;

using Zenject;

using SOLID_VNM.Actors;
using SOLID_VNM.Core.Scenes.TextScene;
using SOLID_VNM.Core.Scenes.ChoiceScene;

namespace SOLID_VNM.Displays.ImageDisplay
{
    public interface IImageDisplayConentVisitor
    {
        void VisitImageDisplayConentSprited(ImageDisplayConentSprited imageConentSprited);
        void VisitImageDisplayConentSpritedAnimated(ImageDisplayConentSpritedAnimated imageConentSpritedAnimated);
    }

    [System.Serializable]
    public abstract class ImageDisplayContent : IDisplayContent, IDisposable
    {
        public abstract void Accept(IImageDisplayConentVisitor imageContentVisitor);
        public abstract void Dispose();
    }

    public class ImageDisplayConentSprited : ImageDisplayContent, IPoolable<Sprite, IMemoryPool>
    {
        private IMemoryPool _memoryPool;
        private Sprite _sprite;

        public Sprite Sprite { get { return _sprite; } }

        public override void Accept(IImageDisplayConentVisitor imageContentVisitor)
        {
            imageContentVisitor.VisitImageDisplayConentSprited(this);
        }

        public void OnDespawned()
        {
        }

        public void OnSpawned(Sprite sprite, IMemoryPool memoryPool)
        {
            _sprite = sprite;
            _memoryPool = memoryPool;
        }

        public override void Dispose()
        {
            _memoryPool.Despawn(this);
        }

        public class Factory : PlaceholderFactory<Sprite, ImageDisplayConentSprited>
        {
        }
    }

    public class ImageDisplayConentSpritedAnimated : ImageDisplayContent, IPoolable<Sprite, AnimationClip, IMemoryPool>
    {
        private IMemoryPool _memoryPool;

        private Sprite _sprite;
        private AnimationClip _animationClip;

        public Sprite Sprite { get { return _sprite; } }
        public AnimationClip AnimationClip { get { return _animationClip; } }

        public override void Accept(IImageDisplayConentVisitor imageContentVisitor)
        {
            imageContentVisitor.VisitImageDisplayConentSpritedAnimated(this);
        }

        public void OnDespawned()
        {
        }

        public override void Dispose()
        {
            _memoryPool.Despawn(this);
        }

        public void OnSpawned(Sprite sprite, AnimationClip animationClip, IMemoryPool memoryPool)
        {
            _sprite = sprite;
            _animationClip = animationClip;
            _memoryPool = memoryPool;
        }

        public class Factory : PlaceholderFactory<Sprite, AnimationClip, ImageDisplayConentSpritedAnimated>
        {
        }
    }
}