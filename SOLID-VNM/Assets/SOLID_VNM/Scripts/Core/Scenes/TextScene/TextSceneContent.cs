using System;

using UnityEngine;

namespace SOLID_VNM.Core.Scenes.DialogueScene
{
    public interface IDialogueSceneModel : ISceneModel
    {
        int ActorId { get; }
        string ActorAction { get; }
        string Text { get; }
        Sprite Background { get; }
    }

    [Serializable]
    public class ConcreteDialogueSceneModel : IDialogueSceneModel
    {
        [SerializeField]
        private int actorId;

        [SerializeField]
        private string actorAction;

        [SerializeField]
        private string text;

        [SerializeField]
        private Sprite background;

        public int ActorId { get { return actorId; } }

        public string ActorAction { get { return actorAction; } }

        public string Text { get { return text; } }

        public Sprite Background { get { return background; } }


        public void Accept(ISceneContentVisitor sceneContentVisitor)
        {
            sceneContentVisitor.Visit(this);
        }
    }
}