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
    public abstract class ImageDisplayContent : IDisposable
    {
        public abstract void Accept(IImageDisplayConentVisitor imageContentVisitor);
        public abstract void Dispose();
    }

    public class ImageDisplayContentExtractor : ISceneContentVisitor
    {
        readonly private ImageDisplayConentSprited.Factory _spritedFactory;
        readonly private ImageDisplayConentSpritedAnimated.Factory _spritedAnimatedFactory;

        readonly private ActorProvider _actorProvider;
        readonly private ActorActionSettings _actorActionSettings;

        private ImageDisplayContent _imageDisplayContent;

        public ImageDisplayContentExtractor(ActorProvider actorProvider, ActorActionSettings actorActionSettings, ImageDisplayConentSprited.Factory spritedFactory, ImageDisplayConentSpritedAnimated.Factory spritedAnimatedFactory)
        {
            _spritedFactory = spritedFactory;
            _spritedAnimatedFactory = spritedAnimatedFactory;
            _actorProvider = actorProvider;
            _actorActionSettings = actorActionSettings;
        }

        public ImageDisplayContent Create(SceneContent sceneContentDialogue)
        {
            Assert.IsNotNull(sceneContentDialogue);
            sceneContentDialogue.Accept(this);
            return _imageDisplayContent;
        }

        private ImageDisplayContent Create(SceneContentDialogue sceneContentDialogue)
        {
            Assert.IsNotNull(sceneContentDialogue);

            Actor actor = _actorProvider.GetActorById(sceneContentDialogue.actorId);

            if (sceneContentDialogue.actorAction == "")
            {
                return _spritedFactory.Create(actor.sprite);
            }
            else
            {
                AnimationClip animationClip = _actorActionSettings.GetAnimationClipByAction(sceneContentDialogue.actorAction);
                return _spritedAnimatedFactory.Create(actor.sprite, animationClip);
            }
        }

        public void Visit(SceneContentDialogue sceneContentDialogue)
        {
            _imageDisplayContent = Create(sceneContentDialogue);
        }

        public void Visit(SceneContentChoice sceneContentChoice)
        {
            _imageDisplayContent = null;
        }
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