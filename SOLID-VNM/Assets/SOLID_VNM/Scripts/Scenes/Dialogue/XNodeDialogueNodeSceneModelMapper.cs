using UnityEngine;

using SOLID_VNM.Actors;

namespace SOLID_VNM.Scenes.Dialogue
{
    public interface XNodeDialogueNodeSceneModelMapper : XNodeSceneModelSceneModelMapper<XNodeDialogueModel, DialogueSceneModel>
    {
    }

    public class XNodeDialogueNodeSceneModelMapperImpl : XNodeDialogueNodeSceneModelMapper
    {
        private readonly DialogueSceneModelImpl.Factory _dialogueSceneModelFactory;

        public XNodeDialogueNodeSceneModelMapperImpl(DialogueSceneModelImpl.Factory dialogueSceneModelFactory)
        {
            _dialogueSceneModelFactory = dialogueSceneModelFactory;
        }

        DialogueSceneModel XNodeSceneModelSceneModelMapper<XNodeDialogueModel, DialogueSceneModel>.From(XNodeDialogueModel model)
        {
            Actor mainActor = model.actor;
            Actor[] actors = new Actor[] { model.actor };
            //TODO : IMPROVE

            string text = model.text;
            Sprite background = model.background;

            return _dialogueSceneModelFactory.Create(mainActor, actors, text, background);
        }
    }
}