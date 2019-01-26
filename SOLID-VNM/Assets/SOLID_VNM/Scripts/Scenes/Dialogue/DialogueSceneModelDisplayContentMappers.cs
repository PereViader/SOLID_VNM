using System.Collections.Generic;

using UnityEngine;

using SOLID_VNM.Actors;
using SOLID_VNM.Displays.ActorDisplay;
using SOLID_VNM.Displays.TextDisplay;
using SOLID_VNM.Displays.BackgroundDisplay;

namespace SOLID_VNM.Scenes.Dialogue
{
    public interface DialogueSceneModelTextDisplayContentMapper : SceneModelDisplayContentMapper<DialogueSceneModel, TextDisplayContent> { }

    public class DialogueSceneModelTextDisplayContentMapperImpl : DialogueSceneModelTextDisplayContentMapper
    {
        private readonly TextDisplayContent.Factory _textDisplayContentFactory;

        public DialogueSceneModelTextDisplayContentMapperImpl(TextDisplayContent.Factory textDisplayContentFactory)
        {
            _textDisplayContentFactory = textDisplayContentFactory;
        }

        TextDisplayContent SceneModelDisplayContentMapper<DialogueSceneModel, TextDisplayContent>.From(DialogueSceneModel dialogueSceneModel)
        {
            string mainActorName = dialogueSceneModel.MainActor.Name;
            string text = dialogueSceneModel.Text;

            return _textDisplayContentFactory.Create(mainActorName, text);
        }
    }

    public interface DialogueSceneModelActorDisplayContentMapper : SceneModelDisplayContentMapper<DialogueSceneModel, ActorDisplayContent> { }

    public class DialogueSceneModelActorDisplayModelMapperImpl : DialogueSceneModelActorDisplayContentMapper
    {
        private readonly ActorDisplayContentImpl.Factory _actorDisplayModelFactory;

        public DialogueSceneModelActorDisplayModelMapperImpl(ActorActionSettings actorActionSettings, ActorDisplayContentImpl.Factory actorDisplayModelFactory)
        {
            _actorDisplayModelFactory = actorDisplayModelFactory;
        }

        ActorDisplayContent SceneModelDisplayContentMapper<DialogueSceneModel, ActorDisplayContent>.From(DialogueSceneModel dialogueSceneModel)
        {
            List<Actor> leftActors = new List<Actor>();
            List<Actor> rightActors = new List<Actor>();

            foreach (Actor actor in dialogueSceneModel.Actors)
            {
                switch (dialogueSceneModel.ActorPosition(actor))
                {
                    case ActorPosition.Left:
                        leftActors.Add(actor);
                        break;
                    case ActorPosition.Right:
                        rightActors.Add(actor);
                        break;
                }
            }

            return _actorDisplayModelFactory.Create(leftActors, rightActors);
        }
    }


    public interface DialogueSceneModelBackgroundDisplayContentMapper : SceneModelDisplayContentMapper<DialogueSceneModel, BackgroundDisplayContent> { }

    public class DialogueSceneModelBackgroundDisplayContentMapperImpl : DialogueSceneModelBackgroundDisplayContentMapper
    {
        private readonly BackgroundDisplayContent.Factory _backgroundDisplayContentFactory;

        public DialogueSceneModelBackgroundDisplayContentMapperImpl(BackgroundDisplayContent.Factory backgroundDisplayContentFactory)
        {
            _backgroundDisplayContentFactory = backgroundDisplayContentFactory;
        }

        BackgroundDisplayContent SceneModelDisplayContentMapper<DialogueSceneModel, BackgroundDisplayContent>.From(DialogueSceneModel dialogueSceneModel)
        {
            return _backgroundDisplayContentFactory.Create(dialogueSceneModel.Background);
        }
    }
}