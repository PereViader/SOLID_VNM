using UnityEngine;

using SOLID_VNM.Actors;
using SOLID_VNM.Displays.ImageDisplay;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;

namespace SOLID_VNM.Core.Scenes.DialogueScene
{

    public interface ISceneContentDialogueTextDisplayContentExtractor : ISceneModelExtractor<IDialogueSceneModel, TextDisplayContent> { }
    public class SceneContentDialogueTextDisplayContentExtractor : ISceneContentDialogueTextDisplayContentExtractor
    {
        private readonly TextDisplayContent.Factory _textDisplayContentFactory;
        private readonly ActorProvider _actorProvider;

        public SceneContentDialogueTextDisplayContentExtractor(TextDisplayContent.Factory textDisplayContentFactory, ActorProvider actorProvider)
        {
            _textDisplayContentFactory = textDisplayContentFactory;
            _actorProvider = actorProvider;
        }

        TextDisplayContent ISceneModelExtractor<IDialogueSceneModel, TextDisplayContent>.Extract(IDialogueSceneModel content)
        {
            Actor actor = _actorProvider.GetActorById(content.ActorId);
            return _textDisplayContentFactory.Create(actor.name, content.Text);
        }
    }

    public interface ISceneContentDialogueImageDisplayContentExtractor : ISceneModelExtractor<IDialogueSceneModel, ImageDisplayContent> { }

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

        ImageDisplayContent ISceneModelExtractor<IDialogueSceneModel, ImageDisplayContent>.Extract(IDialogueSceneModel sceneContentDialogue)
        {
            Actor actor = _actorProvider.GetActorById(sceneContentDialogue.ActorId);

            if (sceneContentDialogue.ActorAction == string.Empty)
            {
                return _spritedFactory.Create(actor.sprite);
            }
            else
            {
                AnimationClip animationClip = _actorActionSettings.GetAnimationClipByAction(sceneContentDialogue.ActorAction);
                return _spritedAnimatedFactory.Create(actor.sprite, animationClip);
            }
        }
    }

    public interface ISceneContentDialogueBackgroundDisplayContentExtractor : ISceneModelExtractor<IDialogueSceneModel, BackgroundDisplayContent> { }

    public class SceneContentDialogueBackgroundDisplayContentExtractor : ISceneContentDialogueBackgroundDisplayContentExtractor
    {
        private readonly BackgroundDisplayContent.Factory _backgroundDisplayContentFactory;

        public SceneContentDialogueBackgroundDisplayContentExtractor(BackgroundDisplayContent.Factory backgroundDisplayContentFactory)
        {
            _backgroundDisplayContentFactory = backgroundDisplayContentFactory;
        }

        BackgroundDisplayContent ISceneModelExtractor<IDialogueSceneModel, BackgroundDisplayContent>.Extract(IDialogueSceneModel sceneContentDialogue)
        {
            return _backgroundDisplayContentFactory.Create(sceneContentDialogue.Background);
        }
    }
}