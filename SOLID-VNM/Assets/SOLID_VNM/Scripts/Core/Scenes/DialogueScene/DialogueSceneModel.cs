using System;

using UnityEngine;

namespace SOLID_VNM.Core.Scenes.DialogueScene
{
    public interface IDialogueSceneModel : ISceneModel
    {
        string MainActorId { get; }
        string Text { get; }
        Sprite Background { get; }

    }

    [Serializable]
    public class ConcreteDialogueSceneModel : IDialogueSceneModel
    {
        [SerializeField]
        private string actorId;

        [SerializeField]
        private string text;

        [SerializeField]
        private Sprite background;

        public string MainActorId { get { return actorId; } }

        public string Text { get { return text; } }

        public Sprite Background { get { return background; } }

        public void Accept(ISceneModelVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}