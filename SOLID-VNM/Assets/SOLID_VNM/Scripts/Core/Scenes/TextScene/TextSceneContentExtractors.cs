using UnityEngine;

using SOLID_VNM.Actors;
using SOLID_VNM.Displays.ImageDisplay;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;

namespace SOLID_VNM.Core.Scenes.TextScene
{

    public interface ISceneContentDialogueTextDisplayContentExtractor : ISceneContentExtractor<SceneContentDialogue, TextDisplayContent> { }
    public class SceneContentDialogueTextDisplayContentExtractor : ISceneContentDialogueTextDisplayContentExtractor
    {
        private readonly TextDisplayContent.Factory _textDisplayContentFactory;
        private readonly ActorProvider _actorProvider;

        public SceneContentDialogueTextDisplayContentExtractor(TextDisplayContent.Factory textDisplayContentFactory, ActorProvider actorProvider)
        {
            _textDisplayContentFactory = textDisplayContentFactory;
            _actorProvider = actorProvider;
        }

        TextDisplayContent ISceneContentExtractor<SceneContentDialogue, TextDisplayContent>.Extract(SceneContentDialogue content)
        {
            Actor actor = _actorProvider.GetActorById(content.actorId);
            return _textDisplayContentFactory.Create(actor.name, content.text);
        }
    }

    public interface ISceneContentDialogueImageDisplayContentExtractor : ISceneContentExtractor<SceneContentDialogue, ImageDisplayContent> { }

    public class SceneContentDialogueImageDisplayContentExtractor : ISceneContentDialogueImageDisplayContentExtractor
    {
        private readonly ImageDisplayConentSprited.Factory _spritedFactory;
        private readonly ImageDisplayConentSpritedAnimated.Factory _spritedAnimatedFactory;

        private readonly ActorProvider _actorProvider;
        private readonly ActorActionSettings _actorActionSettings;

        private ImageDisplayContent _imageDisplayContent;

        public SceneContentDialogueImageDisplayContentExtractor(ActorProvider actorProvider, ActorActionSettings actorActionSettings, ImageDisplayConentSprited.Factory spritedFactory, ImageDisplayConentSpritedAnimated.Factory spritedAnimatedFactory)
        {
            _spritedFactory = spritedFactory;
            _spritedAnimatedFactory = spritedAnimatedFactory;
            _actorProvider = actorProvider;
            _actorActionSettings = actorActionSettings;
        }

        ImageDisplayContent ISceneContentExtractor<SceneContentDialogue, ImageDisplayContent>.Extract(SceneContentDialogue sceneContentDialogue)
        {
            Actor actor = _actorProvider.GetActorById(sceneContentDialogue.actorId);

            if (sceneContentDialogue.actorAction == string.Empty)
            {
                return _spritedFactory.Create(actor.sprite);
            }
            else
            {
                AnimationClip animationClip = _actorActionSettings.GetAnimationClipByAction(sceneContentDialogue.actorAction);
                return _spritedAnimatedFactory.Create(actor.sprite, animationClip);
            }
        }
    }

    public interface ISceneContentDialogueBackgroundDisplayContentExtractor : ISceneContentExtractor<SceneContentDialogue, BackgroundDisplayContent> { }

    public class SceneContentDialogueBackgroundDisplayContentExtractor : ISceneContentDialogueBackgroundDisplayContentExtractor
    {
        private readonly BackgroundDisplayContent.Factory _backgroundDisplayContentFactory;

        public SceneContentDialogueBackgroundDisplayContentExtractor(BackgroundDisplayContent.Factory backgroundDisplayContentFactory)
        {
            _backgroundDisplayContentFactory = backgroundDisplayContentFactory;
        }

        BackgroundDisplayContent ISceneContentExtractor<SceneContentDialogue, BackgroundDisplayContent>.Extract(SceneContentDialogue sceneContentDialogue)
        {
            return _backgroundDisplayContentFactory.Create(sceneContentDialogue.background);
        }
    }
}