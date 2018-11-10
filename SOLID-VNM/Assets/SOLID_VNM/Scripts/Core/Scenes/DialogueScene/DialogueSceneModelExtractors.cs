using UnityEngine;

using SOLID_VNM.Actors;
using SOLID_VNM.Displays.ImageDisplay;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;

namespace SOLID_VNM.Core.Scenes.DialogueScene
{
    public interface IDialogueSceneModelTextDisplayContentExtractor : ISceneModelExtractor<IDialogueSceneModel, TextDisplayContent> { }

    public class ConcreteDialogueSceneModelTextDisplayContentExtractor : IDialogueSceneModelTextDisplayContentExtractor
    {
        private readonly TextDisplayContent.Factory _textDisplayContentFactory;
        private readonly ActorProvider _actorProvider;

        public ConcreteDialogueSceneModelTextDisplayContentExtractor(TextDisplayContent.Factory textDisplayContentFactory, ActorProvider actorProvider)
        {
            _textDisplayContentFactory = textDisplayContentFactory;
            _actorProvider = actorProvider;
        }

        TextDisplayContent ISceneModelExtractor<IDialogueSceneModel, TextDisplayContent>.Extract(IDialogueSceneModel dialogueSceneModel)
        {
            Actor actor = _actorProvider.GetActorById(dialogueSceneModel.ActorId);
            return _textDisplayContentFactory.Create(actor.name, dialogueSceneModel.Text);
        }
    }


    public interface IDialogueSceneModelImageDisplayContentExtractor : ISceneModelExtractor<IDialogueSceneModel, ImageDisplayContent> { }

    public class ConcreteDialogueSceneModelImageDisplayContentExtractor : IDialogueSceneModelImageDisplayContentExtractor
    {
        private readonly ImageDisplayConentSprited.Factory _spritedFactory;
        private readonly ImageDisplayConentSpritedAnimated.Factory _spritedAnimatedFactory;

        private readonly ActorProvider _actorProvider;
        private readonly ActorActionSettings _actorActionSettings;

        private ImageDisplayContent _imageDisplayContent;

        public ConcreteDialogueSceneModelImageDisplayContentExtractor(ActorProvider actorProvider, ActorActionSettings actorActionSettings, ImageDisplayConentSprited.Factory spritedFactory, ImageDisplayConentSpritedAnimated.Factory spritedAnimatedFactory)
        {
            _spritedFactory = spritedFactory;
            _spritedAnimatedFactory = spritedAnimatedFactory;
            _actorProvider = actorProvider;
            _actorActionSettings = actorActionSettings;
        }

        ImageDisplayContent ISceneModelExtractor<IDialogueSceneModel, ImageDisplayContent>.Extract(IDialogueSceneModel dialogueSceneModel)
        {
            Actor actor = _actorProvider.GetActorById(dialogueSceneModel.ActorId);

            if (dialogueSceneModel.ActorAction == string.Empty)
            {
                return _spritedFactory.Create(actor.sprite);
            }
            else
            {
                AnimationClip animationClip = _actorActionSettings.GetAnimationClipByAction(dialogueSceneModel.ActorAction);
                return _spritedAnimatedFactory.Create(actor.sprite, animationClip);
            }
        }
    }


    public interface IDialogueSceneModelBackgroundDisplayContentExtractor : ISceneModelExtractor<IDialogueSceneModel, BackgroundDisplayContent> { }

    public class ConcreteDialogueSceneModelBackgroundDisplayContentExtractor : IDialogueSceneModelBackgroundDisplayContentExtractor
    {
        private readonly BackgroundDisplayContent.Factory _backgroundDisplayContentFactory;

        public ConcreteDialogueSceneModelBackgroundDisplayContentExtractor(BackgroundDisplayContent.Factory backgroundDisplayContentFactory)
        {
            _backgroundDisplayContentFactory = backgroundDisplayContentFactory;
        }

        BackgroundDisplayContent ISceneModelExtractor<IDialogueSceneModel, BackgroundDisplayContent>.Extract(IDialogueSceneModel dialogueSceneModel)
        {
            return _backgroundDisplayContentFactory.Create(dialogueSceneModel.Background);
        }
    }
}