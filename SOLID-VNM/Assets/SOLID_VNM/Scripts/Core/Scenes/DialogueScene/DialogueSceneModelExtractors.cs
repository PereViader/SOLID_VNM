using UnityEngine;

using SOLID_VNM.Actors;
using SOLID_VNM.Displays.ActorDisplay;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;
using System.Collections.Generic;

namespace SOLID_VNM.Core.Scenes.DialogueScene
{
    public interface IDialogueSceneModelTextDisplayContentExtractor : ISceneModelExtractor<IDialogueSceneModel, TextDisplayContent> { }

    public class ConcreteDialogueSceneModelTextDisplayContentExtractor : IDialogueSceneModelTextDisplayContentExtractor
    {
        private readonly TextDisplayContent.Factory _textDisplayContentFactory;
        private readonly IActorProvider _actorProvider;

        public ConcreteDialogueSceneModelTextDisplayContentExtractor(TextDisplayContent.Factory textDisplayContentFactory, IActorProvider actorProvider)
        {
            _textDisplayContentFactory = textDisplayContentFactory;
            _actorProvider = actorProvider;
        }

        TextDisplayContent ISceneModelExtractor<IDialogueSceneModel, TextDisplayContent>.Extract(IDialogueSceneModel dialogueSceneModel)
        {
            IActor actor = _actorProvider.GetActorById(dialogueSceneModel.ActorId);
            return _textDisplayContentFactory.Create(actor.Name, dialogueSceneModel.Text);
        }
    }

    public interface IDialogueSceneModelActorDisplayContentExtractor : ISceneModelExtractor<IDialogueSceneModel, IActorDisplayModel> { }

    public class ConcreteDialogueSceneModelActorDisplayModelExtractor : IDialogueSceneModelActorDisplayContentExtractor
    {
        private readonly ConcreteActorDisplayModel.Factory _actorDisplayModelFactory;

        private readonly IActorProvider _actorProvider;
        private readonly ActorActionSettings _actorActionSettings;

        public ConcreteDialogueSceneModelActorDisplayModelExtractor(IActorProvider actorProvider, ActorActionSettings actorActionSettings, ConcreteActorDisplayModel.Factory actorDisplayModelFactory)
        {
            _actorDisplayModelFactory = actorDisplayModelFactory;
            _actorProvider = actorProvider;
            _actorActionSettings = actorActionSettings;
        }

        IActorDisplayModel ISceneModelExtractor<IDialogueSceneModel, IActorDisplayModel>.Extract(IDialogueSceneModel dialogueSceneModel)
        {
            IActor actor = _actorProvider.GetActorById(dialogueSceneModel.ActorId);
            return _actorDisplayModelFactory.Create(new List<IActor>(), new List<IActor>(new IActor[] { actor })); //TODO add actor left and right
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